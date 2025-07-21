using SoloGames.Configs;
using SoloGames.Tools;
using UnityEngine;

namespace SoloGames.Character
{
    public enum ConditionStates
    {
        Normal,
        Dead,
    }

    public enum MovementStates
    {
        None,
        Idle,
        Running,
        Jumping,
        Attacking,
        Falling
	}
    
    public enum FacingDirections { West, East }

    public class Character : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private CharacterSettingsSO _settings;

        [Header("Abilities")]
        [SerializeField] private CharacterAbility[] _abilities;

        [Header("Bindings")]
        [SerializeField] private GameObject _model;
        [SerializeField] private Health _health;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Animator _animator;

        [Header("Ground Check")]
        [SerializeField] private Transform _groundCheckPoint;
        [SerializeField] private float _groundCheckRadius = 0.1f;

        #region GETTERS
        public CharacterSettingsSO Settings => _settings;
        public GameObject CharacterModel => _model;
        public Animator CharacterAnimator => _animator;
        public SpriteRenderer CharacterSpriteRenderer => _spriteRenderer;
        public Health CharacterHealth => _health;
        public Rigidbody2D Rigidbody => _rigidbody;
        public bool Grounded => _grounded;
        public bool JustGotGrounded => _justGotGrounded;
        public StateMachine<ConditionStates> ConditionState;
        public StateMachine<MovementStates> MovementState;
        #endregion

        protected bool _grounded;
        protected bool _justGotGrounded;
        protected bool _groundedLastFrame;
        protected Collider2D _groundedCheck;

        private void Awake()
        {
            PreInitialization();
        }

        private void PreInitialization()
        {
            ConditionState = new StateMachine<ConditionStates>();
            MovementState = new StateMachine<MovementStates>();
        }

        private void Update()
        {
            CheckIfGrounded();
            ProcessAbilities();
        }

        private void ProcessAbilities()
        {
            foreach (CharacterAbility ability in _abilities)
            {
                if (ability.enabled && ability.AbilityInitialized)
                {
                    ability.ProcessAbility();
                    ability.UpdateAnimator();
                }
            }
        }

        private void CheckIfGrounded()
        {
            _groundedCheck = Physics2D.OverlapCircle(_groundCheckPoint.position, _groundCheckRadius, _settings.GroundLayerMask);
            _grounded = _groundedCheck != null;
            _justGotGrounded = !_groundedLastFrame && _grounded;
            _groundedLastFrame = _grounded;
        }

    }
}
