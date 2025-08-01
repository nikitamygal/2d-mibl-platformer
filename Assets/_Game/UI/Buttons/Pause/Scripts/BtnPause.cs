using SoloGames.Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SoloGames.UI
{
    [RequireComponent(typeof(Button))]
    public class BtnPause : MonoBehaviour
    {
        private Button _btn;
        private UIPopupManager _popupManager;

        [Inject]
        public void Construct(UIPopupManager popupManager)
        {
            _popupManager = popupManager;
        }
        
        private void Awake()
        {
            _btn = GetComponent<Button>();
        }

        public void OnPause()
        {
            _popupManager?.ShowPopup(PopupTypes.Pause);
        }

        private void OnEnable()
        {
            _btn?.onClick.AddListener(OnPause);
        }

        private void OnDisable()
        {
            _btn?.onClick.RemoveListener(OnPause);
        }

    }
}
