using SoloGames.Configs;
using SoloGames.SaveLoad;
using UnityEngine;
using Zenject;


namespace SoloGames.Managers
{
    public class LevelManager : MonoBehaviour
    {
        protected LevelSettingsSO _currentLevel;
        private LevelListSO _levelList;
        private SaveSystem _saveSystem;
        private DiContainer _container;

        [Inject]
        public void Construct(LevelListSO levelList, SaveSystem saveSystem, DiContainer container)
        {
            _levelList = levelList;
            _saveSystem = saveSystem;
            _container = container;
        }

        private void Start()
        {
            _currentLevel = GetCurrentLevelSettings();
            CreateLevelPrefab();
        }

        private LevelSettingsSO GetCurrentLevelSettings()
        {
            int levelNumber = _saveSystem.GetCurrentLevelIndex();
            return _levelList.GetLevelSettings(levelNumber);
        }

        private void CreateLevelPrefab()
        {
            if (_currentLevel == null || _currentLevel.LevelPrefab == null) return;
            GameObject levelObject = _container.InstantiatePrefab(_currentLevel.LevelPrefab);
            levelObject.transform.position = Vector2.zero;
        }

    }
}