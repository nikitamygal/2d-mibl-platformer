using SoloGames.UI;
using UnityEngine;

namespace SoloGames.Characters
{
    public class CharacterJump : CharacterAbility
    {
        protected float _settingsJumpForce => _character.Settings.JumpForce;
		protected bool _buttonReleased = false;
		protected bool _jumpStopped = false;
        protected bool _hasJumped;

        public override void ProcessAbility()
        {
            base.ProcessAbility();
            HandleInput();
        }

        protected void HandleInput()
        { 
            if (_character.ConditionState.CurrentState != ConditionStates.Normal)
            {
                return;
            }
            if (_inputManager.JumpButton.State.CurrentState == ButtonStates.ButtonDown)
            {
                JumpStart();
            }
            if (_inputManager.JumpButton.State.CurrentState == ButtonStates.ButtonUp)
            {
                _buttonReleased = true;
            }
        }

        private void FixedUpdate()
        {
            // if (_jumpStopped) return;

            if (_character.MovementState.CurrentState == MovementStates.Jumping && !_hasJumped)
            {
                _character.Rigidbody.AddForce(Vector2.up * _settingsJumpForce, ForceMode2D.Impulse);
                _hasJumped = true;
            }

            if (_character.Grounded)
            {
                if (_hasJumped)
                {
                    _character.MovementState.ChangeState(MovementStates.Idle);
                    _hasJumped = false;
                    JumpStop();
                }
            }
        }

        protected virtual void JumpStart()
        {
            _character.MovementState.ChangeState(MovementStates.Jumping);

            // _jumpStopped = false;
            _buttonReleased = false;
        }

		protected virtual void JumpStop()
		{
			// _jumpStopped = true;
			_character.MovementState.ChangeState(MovementStates.Idle);
			_buttonReleased = false;
		}

        public override void UpdateAnimator()
        {
            _character.CharacterAnimator.SetBool(AnimationParameters.Jumping, _character.MovementState.CurrentState == MovementStates.Jumping);
            _character.CharacterAnimator.SetBool(AnimationParameters.Grounded, _character.JustGotGrounded);
        }
    }
}
