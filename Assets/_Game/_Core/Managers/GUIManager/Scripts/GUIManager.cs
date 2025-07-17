using UnityEngine;


namespace SoloGames.Managers
{
    public class GUIManager : SingletonPerScene<GUIManager>
    {
        [SerializeField] private GameObject _pausePanel;

        private void Start()
        {
            SetPausePanel(false);
        }

        public void SetPausePanel(bool state)
        {
            if (_pausePanel == null) return;
            _pausePanel.SetActive(state);
        }
    }
}
