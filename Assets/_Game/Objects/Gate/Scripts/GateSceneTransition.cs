using SoloGames.Managers;
using SoloGames.SaveLoad;
using UnityEngine;
using Zenject;

namespace SoloGames.Gameplay
{
    public enum TransitionType { Forward, Backward }

    public class GateSceneTransition : MonoBehaviour
    {
        [SerializeField] private TransitionType _transition;

        private SaveSystem _saveSystem;
        private UIPopupManager _popupManager;

        [Inject]
        public void Construct(SaveSystem saveSystem, UIPopupManager popupManager)
        {
            _saveSystem = saveSystem;
            _popupManager = popupManager;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == Tags.Player)
            {
                SceneTransition();
            }
        }

        private void SceneTransition()
        {
            int currentLevelIndex = _saveSystem.GetCurrentLevelIndex();
            int nextLevelIndex = _transition == TransitionType.Forward ? currentLevelIndex + 1 : currentLevelIndex - 1;
            if (nextLevelIndex < 0)
                nextLevelIndex = 0;

            _saveSystem.SetCurrentLevelNumber(nextLevelIndex);
            _popupManager.ShowPopup(PopupTypes.LevelCompleted);
        }
    }
}
