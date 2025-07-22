using UnityEngine;

namespace SoloGames.Characters
{
    public class CharacterOrientation : CharacterAbility
    {
        [SerializeField] private bool _modelShouldFlip = true;
        [SerializeField] private Vector3 _modelFlipValueLeft = new Vector3(-1, 1, 1);
		[SerializeField] private Vector3 _modelFlipValueRight = new Vector3(1, 1, 1);
        [SerializeField] private FacingDirections _initialFacingDirection = FacingDirections.East;
        [SerializeField] private float _absoluteThresholdMovement = 0.5f;

        protected int _direction;

        protected override void PreInitialization()
        {
            base.PreInitialization();
            if (_initialFacingDirection == FacingDirections.West)
            {
                _direction = -1;
            }
            else
            {
                _direction = 1;
            }
            Face(_initialFacingDirection);
        }

        public override void ProcessAbility()
        {
            base.ProcessAbility();
			FlipToFaceMovementDirection();
        }

		protected virtual void FlipToFaceMovementDirection()
		{
            if (_inputManager.PrimaryMovement.normalized.magnitude >= _absoluteThresholdMovement)
            {
                float checkedDirection = (Mathf.Abs(_inputManager.PrimaryMovement.normalized.x) > 0) ? _inputManager.PrimaryMovement.normalized.x : 0;

                if (checkedDirection >= 0)
                {
                    _character.FaceDirection = FacingDirections.East;
                }
                else
                {
                    _character.FaceDirection = FacingDirections.West;
                }
                Face(_character.FaceDirection);
            }                
		}

        public virtual void Face(FacingDirections direction)
        {
            if (direction == FacingDirections.West)
            {
                FaceDirection(-1);
            }
            if (direction == FacingDirections.East)
            {
                FaceDirection(1);
            }
        }

        protected void FaceDirection(int direction)
        {
            if (_modelShouldFlip)
            {
                FlipModel(direction);
            }
        }
        
        protected void FlipModel(int direction)
		{
            if (_character.CharacterModel != null)
            {
                _character.CharacterModel.transform.localScale = (direction == 1) ? _modelFlipValueRight : _modelFlipValueLeft;
            }
            else
            {
                _character.CharacterSpriteRenderer.flipX = direction == -1;
            }
		}

    }
}
