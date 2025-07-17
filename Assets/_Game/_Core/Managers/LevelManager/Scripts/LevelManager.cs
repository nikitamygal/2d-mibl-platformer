using System.Collections.Generic;
using SoloGames.Configs;
using SoloGames.SaveLoad;
using UnityEngine;

namespace SoloGames.Managers
{
    public class LevelManager : SingletonPerScene<LevelManager>
    {
        [SerializeField] private LevelListSO _levelList;

        protected LevelSettingsSO _currentLevel;

        protected override void Awake()
        {
            base.Awake();
            _currentLevel = GetCurrentLevelSettings();
            CreateLevelPrefab();
        }

        public LevelSettingsSO GetCurrentLevelSettings()
        {
            int levelNumber = SaveSystem.GetLevelIndex();
            return _levelList.GetLevelSettings(levelNumber);
        }

        public void CreateLevelPrefab()
        {
            if (_currentLevel == null || _currentLevel.LevelPrefab == null) return;
            GameObject levelObject = Instantiate(_currentLevel.LevelPrefab);
            levelObject.transform.position = Vector2.zero;
        }
    }
}