using System;
using UnityEngine;

namespace SoloGames.Characters
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private bool _addKnockbackOnDamage = true;
        [SerializeField] private bool _destroyOnDeath = true;
        [SerializeField] private bool _disableColliderOnDeath = true;
        [SerializeField] private float _delayBeforeDestruction = 0f;
        [SerializeField] private Animator _animator;

        protected float _currentHealth;
        protected float _maxHealth;
        protected Character _character;
        protected Collider2D _collider;
        protected Vector2 _knockbackSettings => _character.Settings.KnockbackDirection;

        public event Action OnHit;
        public event Action OnDeath;

        private void Awake()
        {
            Initialization();
        }

        private void Initialization()
        {
            _character = this.gameObject.GetComponentInParent<Character>();
            _collider = this.gameObject.GetComponent<Collider2D>();
            GetAnimator();
            SetCurrentHealth();
        }

        #region PUBLIC
        public void SetHealth(float newValue)
        {
            _currentHealth = newValue;
        }

        public void ReviveHealth()
        {
            _currentHealth = _maxHealth;
        }

        public void Damage(float damage)
        {
            SetHealth(_currentHealth - damage);
            OnHit?.Invoke();
            _animator?.SetTrigger(AnimationParameters.Hit);


            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Death();
            }
            else
            {
                AddKnockback();
            }
        }

        public void Death()
        {
            SetHealth(0);
            _animator?.SetTrigger(AnimationParameters.Death);
            OnDeath?.Invoke();

            if (_character.Rigidbody != null)
            {
                _character.Rigidbody.simulated = false;
            }

            if (_disableColliderOnDeath && _collider != null)
            {
                _collider.enabled = false;
            }
            if (_destroyOnDeath)
            {
                if (_delayBeforeDestruction > 0f)
                {
                    Invoke("DestroyObject", _delayBeforeDestruction);
                }
                else
                {
                    DestroyObject();
                }
            }
        }

        public void AddKnockback()
        {
            if (!_addKnockbackOnDamage) return;

            Vector2 knockBackDirection = _character.FaceDirection == FacingDirections.West ? Vector2.left : Vector2.right;
            _character.Rigidbody.velocity = _knockbackSettings;
        }
        #endregion

        protected void DestroyObject()
        {
            Destroy(gameObject);
        }

        protected void SetCurrentHealth()
        {
            if (_character?.Settings != null)
            {
                SetHealth(_character.Settings.Health);
                _maxHealth = _character.Settings.Health;
            }
        }

        protected void GetAnimator()
        {
            if (_character?.CharacterAnimator != null)
            {
                _animator = _character.CharacterAnimator;
            }
        }

    }
}
