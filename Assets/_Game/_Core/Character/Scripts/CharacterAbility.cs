using SoloGames.Managers;
using UnityEngine;

namespace SoloGames.Character
{
	public class CharacterAbility : MonoBehaviour
	{
		protected Character _character;
		protected Health _health;
		protected InputManager _inputManager => InputManager.Instance; // TODO temp
		protected bool _abilityInitialized = false;

		public virtual bool AbilityInitialized { get { return _abilityInitialized; } }

		private void Awake()
		{
			PreInitialization();
		}

		protected virtual void PreInitialization()
		{
			_character = this.gameObject.GetComponentInParent<Character>();
			_health = _character.CharacterHealth;
			_abilityInitialized = true;
		}

		public virtual void ProcessAbility()
		{
		}

		public virtual void ResetAbility()
		{
		}
		
		public virtual void UpdateAnimator()
		{
		}
    }
}
