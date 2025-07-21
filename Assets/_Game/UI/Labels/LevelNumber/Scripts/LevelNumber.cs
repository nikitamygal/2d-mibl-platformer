using SoloGames.SaveLoad;
using TMPro;
using UnityEngine;
using Zenject;


namespace SoloGames.UI
{
    public class LevelNumber : MonoBehaviour
    {
        [SerializeField] private string levelPattern = "Level {0}";
        [SerializeField] private TextMeshProUGUI _textLevel;

        private SaveSystem _saveSystem;

        [Inject]
        public void Construct(SaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
        }

        private void Awake()
        {
            ProjectContext.Instance.Container.Inject(this);
        }

        private void Start()
        {
            SetLevelNumber();
        }

        private void SetLevelNumber()
        {
            if (_textLevel == null) return;
            int level = _saveSystem.GetCurrentLevelIndex();
            _textLevel.text = string.Format(levelPattern, level + 1);
        }
    }
}
