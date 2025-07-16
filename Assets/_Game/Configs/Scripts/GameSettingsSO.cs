using UnityEngine;

namespace SoloGames.Configs
{
    [CreateAssetMenu(menuName = "Game/Configs/Game Settings", fileName = "Game Settings")]
    public class GameSettingsSO : ScriptableObject
    {
        [Header("States")]
        public float PrepareStateDelay = 1.0f;
        public float BattleStartStateDelay = 1.0f;
        public float BattleStopStateDelay = 1.0f;
    }
}
