using System;
using SoloGames.Managers;
using UnityEngine;
using Zenject;

namespace SoloGames.Characters
{
    [RequireComponent(typeof(Character))]
    public class CharacterOnDeath : MonoBehaviour
    {
        private Character _player;
        private UIPopupManager _popupManager;

        [Inject]
        public void Construct(UIPopupManager popupManager)
        {
            _popupManager = popupManager;
        }

        private void Awake()
        {
            _player = GetComponent<Character>();
        }

        private void OnEnable()
        {
            _player.CharacterHealth.OnDeath += HandleGameOver;
        }

        private void OnDisable()
        {
            _player.CharacterHealth.OnDeath -= HandleGameOver;
        }

        private void HandleGameOver()
        {
            _popupManager.ShowPopup(PopupTypes.GameOver);
        }

    }
}
