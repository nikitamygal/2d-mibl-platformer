using System;
using UnityEngine;

namespace SoloGames.Character
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private bool _destroyOnDeath = true;
        [SerializeField] private Animator _animator;

        private float _currentHealth;
        private float _maxHealth;
        private Character _character;
        private readonly string _damageAnimParam = "Damage";
        private readonly string _deathAnimParam = "Death";

        public event Action OnHit;
        public event Action OnDeath;

        private void Awake()
        {
            Initialization();
        }

        private void Initialization()
        {
            _character = this.gameObject.GetComponentInParent<Character>();
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
            _animator?.SetTrigger(_damageAnimParam);

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Death();
            }
        }

        public void Death()
        {
            SetHealth(0);
            _animator?.SetTrigger(_deathAnimParam);
            OnDeath?.Invoke();

            if (_destroyOnDeath)
            {
                Destroy(gameObject);
            }
        }
        #endregion

        private void SetCurrentHealth()
        {
            if (_character?.Settings != null)
            {
                SetHealth(_character.Settings.Health);
                _maxHealth = _character.Settings.Health;
            }
        }

        private void GetAnimator()
        {
            if (_character?.CharacterAnimator != null)
            {
                _animator = _character.CharacterAnimator;
            }
        }

    }
}
