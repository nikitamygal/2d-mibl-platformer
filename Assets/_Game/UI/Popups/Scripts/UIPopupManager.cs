using System;
using System.Collections.Generic;
using System.Linq;
using SoloGames.UI;
using UnityEngine;
using Zenject;

namespace SoloGames.Managers
{
    [Serializable]
    public class PopupEntity
    {
        public PopupTypes PopupType;
        public GameObject PopupPrefab;
        public UIPopup PopupUI;
    }

    public class UIPopupManager : MonoBehaviour
    {
        [SerializeField] private RectTransform _overlay;
        [SerializeField] private List<PopupEntity> _popups;

        [Inject] private DiContainer _container;
        private PopupEntity _currentPopup;

        private void Start()
        {
            CreatePopups();
            SetOverlayState(false);
            HideAllPopups();
        }

        private void CreatePopups()
        {
            foreach (PopupEntity popup in _popups)
            {
                GameObject instance = _container.InstantiatePrefab(popup.PopupPrefab);
                instance.transform.SetParent(transform, worldPositionStays: false);
                instance.transform.localPosition = Vector2.zero;
                popup.PopupUI = instance.GetComponent<UIPopup>();
            }
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
