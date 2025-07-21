using UnityEngine;

namespace SoloGames.SaveLoad {

    public class SaveSystem
    {
        public int DefaultLevelIndex = 0;

        public int GetCurrentLevelIndex()
        {
            if (!HasLevelIndexKey()) return DefaultLevelIndex;
            return PlayerPrefs.GetInt(PrefConstants.LevelIndex);
        }

        public void SetCurrentLevelNumber(int level)
        {
            PlayerPrefs.SetInt(PrefConstants.LevelIndex, level);
        }
        
        private bool HasLevelIndexKey()
        {
            return PlayerPrefs.HasKey(PrefConstants.LevelIndex);
        }

    }
}
