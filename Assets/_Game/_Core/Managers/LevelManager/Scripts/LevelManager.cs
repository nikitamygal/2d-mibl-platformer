using System.Collections.Generic;
using SoloGames.Cam;
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

        private LevelSettingsSO GetCurrentLevelSettings()
        {
            int levelNumber = SaveSystem.GetCurrentLevelIndex();
            return _levelList.GetLevelSettings(levelNumber);
        }

        private void CreateLevelPrefab()
        {
            if (_currentLevel == null || _currentLevel.LevelPrefab == null) return;
            GameObject levelObject = Instantiate(_currentLevel.LevelPrefab);
            levelObject.transform.position = Vector2.zero;
        }

        private void SetCameraFollowTarget()
        {
            // PlayerCharacter
            // CameraFollow.Instance.SetTarget();
        }
    }
}