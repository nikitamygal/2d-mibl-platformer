using System.Collections;
using SoloGames.Damage;
using SoloGames.UI;
using UnityEngine;

namespace SoloGames.Characters
{
    public class CharacterShoot : CharacterAbility
    {
        [SerializeField] private Transform _gunSpawnPoint;
        [SerializeField] private GameObject _projectilePrefab;

        protected float _settingsAttackInterval => _character.Settings.AttackInterval;
        protected bool _shooting = false;
        protected IEnumerator _shootingCoroutine;

        protected override void PreInitialization()
        {
            base.PreInitialization();

            _shootingCoroutine = ShootingLoop();
        }

        public override void ProcessAbility()
        {
            base.ProcessAbility();
            HandleInput();
        }

        protected void HandleInput()
        {
            if (!_shooting && _inputManager.FireButton.State.CurrentState == ButtonStates.ButtonDown)
            {
                ShootingStart();
            }
            if (_shooting && _inputManager.FireButton.State.CurrentState == ButtonStates.ButtonUp)
            {
                ShootingStop();
            }
        }

        protected void ShootingStart()
        {
            _shooting = true;
            StartCoroutine(_shootingCoroutine);
        }

        protected void ShootingStop()
        {
            _shooting = false;
            StopCoroutine(_shootingCoroutine);
        }

        private IEnumerator ShootingLoop()
        {
            while (true)
            {
                GameObject newProjectile = Instantiate(_projectilePrefab, _gunSpawnPoint.position, Quaternion.identity);
                Projectile projectile = newProjectile.GetComponent<Projectile>();
                projectile?.SetOwner(_character);
                yield return new WaitForSeconds(_settingsAttackInterval);
            }
        }

        public override void UpdateAnimator()
        {
            _character.CharacterAnimator.SetBool(AnimationParameters.Shooting, _shooting);
        }
        
    }
}
