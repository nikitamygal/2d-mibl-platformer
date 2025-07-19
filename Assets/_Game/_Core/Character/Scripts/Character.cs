using SoloGames.Configs;
using UnityEngine;

namespace SoloGames.Character
{
    public class Character : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private CharacterSettingsSO _settings;

        [Header("Abilities")]
        [SerializeField] private CharacterAbility[] _abilities;

        [Header("Bindings")]
        [SerializeField] private Health _health;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Animator _animator;

        #region GETTERS
        public CharacterSettingsSO Settings => _settings;
        public Animator CharacterAnimator => _animator;
        #endregion


    }
}
