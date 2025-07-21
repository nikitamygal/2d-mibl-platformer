using UnityEngine;

namespace SoloGames.Character
{

    public class CharacterMovement : CharacterAbility
    {
        protected float _settingsSpeed => _character.Settings.MoveSpeed;
        protected float _settingsAcceleration => _character.Settings.Acceleration;
        protected float _settingsDeceleration => _character.Settings.Deceleration;
        protected float _settingsIdleThreshold => _character.Settings.IdleThreshold;
        protected Vector3 _movementVector;
        protected Vector2 _currentInput = Vector2.zero;
        protected Vector2 _normalizedInput;
        protected Vector2 _lerpedInput = Vector2.zero;
        protected Vector3 _currentMovement;
        protected Vector3 _orientedMovement;
        protected float _acceleration = 0f;

        protected override void PreInitialization()
        {
            base.PreInitialization();
            ResetAbility();
        }

        public override void ResetAbility()
        {
	        base.ResetAbility();
			_character.MovementState.ChangeState(MovementStates.Idle);
		}

        public override void ProcessAbility()
        {
            base.ProcessAbility();
            HandleState();
            HandleMovement();
        }

        protected void CheckJustGotGrounded()
        {
            if (_character.JustGotGrounded)
            {
                _character.MovementState.ChangeState(MovementStates.Idle);
            }
        }

        protected void CheckForFalling()
        {
            if (!_character.Grounded
                && (_character.ConditionState.CurrentState == ConditionStates.Normal)
                && (
                    (_character.MovementState.CurrentState == MovementStates.Running)
                    || (_character.MovementState.CurrentState == MovementStates.Idle)
                ))
            {
                _character.MovementState.ChangeState(MovementStates.Falling);
            }
        }

        protected void HandleState()
        {
            if (_character.ConditionState.CurrentState != ConditionStates.Normal)
            {
                return;
            }

            CheckJustGotGrounded();
            CheckForFalling();

            if (_character.Grounded && (_character.MovementState.CurrentState == MovementStates.Falling))
            {
                _character.MovementState.ChangeState(MovementStates.Idle);
            }

            // Idle => Walking
            if (_character.Grounded
                && (_currentMovement.magnitude > _settingsIdleThreshold)
                && (_character.MovementState.CurrentState == MovementStates.Idle))
            {
                _character.MovementState.ChangeState(MovementStates.Running);
            }

            // Walking => Idle
            if ((_character.MovementState.CurrentState == MovementStates.Running)
                && (_currentMovement.magnitude <= _settingsIdleThreshold))
            {
                _character.MovementState.ChangeState(MovementStates.Idle);
            }
        }

        protected void HandleMovement()
        {
            _movementVector = Vector3.zero;
            _currentInput = Vector2.zero;
            _currentInput.x = _inputManager.PrimaryMovement.x;
            _currentInput.y = _inputManager.PrimaryMovement.y;
            _normalizedInput = _currentInput.normalized;

            if ((_settingsAcceleration == 0) || (_settingsDeceleration == 0))
            {
                _lerpedInput = _normalizedInput;
            }
            else
            {
                if (_normalizedInput.magnitude == 0)
                {
                    _acceleration = Mathf.Lerp(_acceleration, 0f, _settingsDeceleration * Time.deltaTime);
                    _lerpedInput = Vector2.Lerp(_lerpedInput, _lerpedInput * _acceleration, Time.deltaTime * _settingsDeceleration);
                }
                else
                {
                    _acceleration = Mathf.Lerp(_acceleration, 1f, _settingsAcceleration * Time.deltaTime);
                    _lerpedInput = Vector2.ClampMagnitude(_currentInput, _acceleration);
                }
            }

            _movementVector.x = _lerpedInput.x;
            _movementVector.y = 0f;
            _movementVector.z = _lerpedInput.y;
            _movementVector *= _settingsSpeed;

            if ((_currentInput.magnitude <= _settingsIdleThreshold) && (_currentMovement.magnitude < _settingsIdleThreshold))
            {
                _movementVector = Vector3.zero;
            }

            _orientedMovement = _movementVector;
            _orientedMovement.y = _orientedMovement.z;
            _orientedMovement.z = 0f;
            _currentMovement = _orientedMovement;
        }

        private void FixedUpdate()
        {
            Vector2 velocity = _character.Rigidbody.velocity;
            velocity.x = _currentMovement.x;
            _character.Rigidbody.velocity = velocity;
        }

        public override void UpdateAnimator()
        {
            _character.CharacterAnimator.SetBool(AnimationParameters.Running, _character.MovementState.CurrentState == MovementStates.Running);
		}

    }
}
