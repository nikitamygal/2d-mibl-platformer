using System;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : SingletonPerScene<PopupManager>
{
    [Serializable]
    public class PopupEntry
    {
        public PopupType popupType;
        public GameObject popupObject;
    }

    [Header("Popup Prefabs or Scene References")]
    [SerializeField] private List<PopupEntry> popupEntries;

    private Dictionary<PopupType, GameObject> _popupMap;
    private GameObject _currentPopup;

    protected override void Awake()
    {
        base.Awake();
        _popupMap = new Dictionary<PopupType, GameObject>();

        foreach (var entry in popupEntries)
        {
            _popupMap[entry.popupType] = entry.popupObject;
            entry.popupObject.SetActive(false);
        }
    }

    public void ShowPopup(PopupType type)
    {
        HideCurrentPopup();

        if (_popupMap.TryGetValue(type, out var popup))
        {
            popup.SetActive(true);
            _currentPopup = popup;

            if (popup.TryGetComponent<IPopup>(out var popupScript))
                popupScript.Show();
        }
        else
        {
            Debug.LogWarning($"PopupManager: Popup of type {type} not found.");
        }
    }

    public void HideCurrentPopup()
    {
        if (_currentPopup != null)
        {
            if (_currentPopup.TryGetComponent<IPopup>(out var popupScript))
                popupScript.Hide();

            _currentPopup.SetActive(false);
            _currentPopup = null;
        }
    }
}