using UnityEngine;

namespace SoloGames.Configs
{
    [CreateAssetMenu(menuName = "Game/Configs/Character Settings", fileName = "Character Settings")]
    public class CharacterSettingsSO : ScriptableObject
    {
        public int Health;
        public float Attack;
        public float MoveSpeed;
        public float JumpForce;
    }
}
