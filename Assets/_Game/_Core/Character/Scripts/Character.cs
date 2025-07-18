using SoloGames.Configs;
using UnityEngine;

namespace SoloGames.Gameplay
{
    public class Character : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private CharacterSettingsSO _settings;

        [Header("Abilities")]
        [SerializeField] private CharacterAbility[] _abilities;

        [Header("Bindings")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Animator _animator;


    }
}
