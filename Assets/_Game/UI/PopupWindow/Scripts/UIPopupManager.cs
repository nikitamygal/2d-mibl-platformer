using System;
using System.Collections.Generic;
using System.Linq;
using SoloGames.UI;
using UnityEngine;

namespace SoloGames.Managers
{

    [Serializable]
    public class PopupEntity
    {
        public PopupTypes PopupType;
        public UIPopup PopupUI;
    }

    public class UIPopupManager : SingletonPerScene<UIPopupManager>
    {
        [SerializeField] private RectTransform _overlay;
        [SerializeField] private List<PopupEntity> _popups;

        private PopupEntity _currentPopup;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            SetOverlayState(false);
            HideAllPopups();
        }

        public void SetOverlayState(bool state)
        {
            if (_overlay == null) return;
            _overlay.gameObject.SetActive(state);
        }

        public void HideAllPopups()
        {
            foreach (PopupEntity popup in _popups)
            {
                popup.PopupUI?.Hide();
            }
        }

        public PopupEntity GetPopupByType(PopupTypes popupType)
        {
            if (_popups.Count == 0) return null;
            return _popups.FirstOrDefault(popup => popup.PopupType == popupType);
        }

        public void ShowPopup(PopupTypes type)
        {
            PopupEntity popupEntity = GetPopupByType(type);
            if (popupEntity == null) return;
            _currentPopup = popupEntity;

            SetOverlayState(true);
            _currentPopup.PopupUI?.Show();
        }

        public void HideCurrentPopup()
        {
            if (_currentPopup == null) return;

            SetOverlayState(false);
            _currentPopup.PopupUI?.Hide();
            _currentPopup = null;
        }

    }
}
