using SoloGames.SaveLoad;
using TMPro;
using UnityEngine;


namespace SoloGames.UI
{
    public class LevelNumber : MonoBehaviour
    {
        [SerializeField] private string levelPattern = "Level {0}";
        [SerializeField] private TextMeshProUGUI _textLevel;

        private void Start()
        {
            SetLevelNumber();
        }

        private void SetLevelNumber()
        {
            if (_textLevel == null) return;
            int level = SaveSystem.GetCurrentLevelIndex();
            _textLevel.text = string.Format(levelPattern, level + 1);
        }
    }
}
