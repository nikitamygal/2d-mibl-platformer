using UnityEngine;

namespace SoloGames.Configs
{
    [CreateAssetMenu(menuName = "Game/Configs/Character Settings", fileName = "Character Settings")]
    public class CharacterSettingsSO : ScriptableObject
    {
        public float Health = 10f;
        public float Attack = 10f;
        public float MoveSpeed = 7f;
        public float Acceleration = 10f;
        public float Deceleration = 10f;
        public float IdleThreshold = 0.05f;
        public float JumpForce = 10f;
        public  LayerMask GroundLayerMask;
    }
}
