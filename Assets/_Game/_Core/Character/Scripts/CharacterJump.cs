using SoloGames.UI;
using UnityEngine;

namespace SoloGames.Characters
{
    public class CharacterJump : CharacterAbility
    {
        protected float _jumpForce => _character.Settings.JumpForce;

        private bool _jumpPressed = false;
        private bool _hasJumped = false;

        public override void ProcessAbility()
        {
            base.ProcessAbility();
            HandleInput();
            HandleState();
        }

        protected void HandleInput()
        {
            if (_character.ConditionState.CurrentState != ConditionStates.Normal) return;

            if (_inputManager.JumpButton.State.CurrentState == ButtonStates.ButtonDown)
            {
                _jumpPressed = true;
            }

            if (_inputManager.JumpButton.State.CurrentState == ButtonStates.ButtonUp)
            {
                _jumpPressed = false;
            }
        }

        protected void HandleState()
        {
            // Jumping
            if (_jumpPressed)
            {
                if (_character.Grounded && !_hasJumped)
                {
                    _character.MovementState.ChangeState(MovementStates.Jumping);
                    _hasJumped = true;
                    Jump();
                }
            }

            // Landing
            if (_character.JustGotGrounded && _hasJumped)
            {
                _hasJumped = false;

                if (_character.MovementState.CurrentState is MovementStates.Falling or MovementStates.Jumping)
                {
                    _character.MovementState.ChangeState(MovementStates.Idle);
                }
            }
        }

        protected void Jump()
        {
            if (_character.MovementState.CurrentState != MovementStates.Jumping) return;
            _character.Rigidbody.velocity = new Vector2(_character.Rigidbody.velocity.x, 0f);
            _character.Rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        public override void UpdateAnimator()
        {
            _character.CharacterAnimator.SetBool(AnimationParameters.Jumping, _hasJumped && _character.MovementState.CurrentState == MovementStates.Jumping);
            _character.CharacterAnimator.SetBool(AnimationParameters.Grounded, _character.Grounded);
        }
    }
}