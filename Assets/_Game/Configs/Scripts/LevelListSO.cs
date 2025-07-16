using System.Collections.Generic;
using UnityEngine;

namespace SoloGames.Configs
{
    [CreateAssetMenu(menuName = "Game/Configs/Level List", fileName = "Level List")]
    public class LevelListSO : ScriptableObject
    {
        public List<LevelSettingsSO> Levels = new List<LevelSettingsSO>();
    }
}
