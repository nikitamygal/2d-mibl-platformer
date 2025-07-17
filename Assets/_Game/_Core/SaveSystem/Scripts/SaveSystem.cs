using SoloGames.Configs;
using UnityEngine;

namespace SoloGames.SaveLoad {

    public static class SaveSystem
    {
        public static string LevelIndex = "LevelIndex";
        public static int DefaultLevelIndex = 0;

        public static int GetCurrentLevelIndex()
        {
            if (!HasLevelIndexKey()) return DefaultLevelIndex;
            return PlayerPrefs.GetInt(LevelIndex);
        }

        public static void SetCurrentLevelNumber(int level)
        {
            PlayerPrefs.SetInt(LevelIndex, level);
        }
        
        private static bool HasLevelIndexKey()
        {
            return PlayerPrefs.HasKey(LevelIndex);
        }

    }
}
