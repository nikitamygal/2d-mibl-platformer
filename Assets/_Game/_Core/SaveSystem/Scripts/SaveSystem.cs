using UnityEngine;

namespace SoloGames.SaveLoad {

    public static class SaveSystem
    {
        public static int DefaultLevelIndex = 0;

        public static int GetCurrentLevelIndex()
        {
            if (!HasLevelIndexKey()) return DefaultLevelIndex;
            return PlayerPrefs.GetInt(PrefConstants.LevelIndex);
        }

        public static void SetCurrentLevelNumber(int level)
        {
            PlayerPrefs.SetInt(PrefConstants.LevelIndex, level);
        }
        
        private static bool HasLevelIndexKey()
        {
            return PlayerPrefs.HasKey(PrefConstants.LevelIndex);
        }

    }
}
