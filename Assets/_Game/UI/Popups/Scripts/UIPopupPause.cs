using SoloGames.Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace SoloGames.UI
{
    public class UIPopupPause : UIPopup
    {
        [SerializeField] private Button _btnContinue;

        private GameplayManager _gameplayManager;

        [Inject]
        public void Construct(GameplayManager gameplayManager)
        {
            _gameplayManager = gameplayManager;
        }

        public override void Show()
        {
            base.Show();
            _gameplayManager?.Pause();
        }

        public override void Hide()
        {
            base.Hide();
            _gameplayManager?.UnPause();
        }

        public override void OnClosePopup()
        {
            base.OnClosePopup();
            _gameplayManager?.UnPause();
        }

        protected override void BindListeners()
        {
            base.BindListeners();
            _btnContinue?.onClick.AddListener(OnClosePopup);
        }

        protected override void UnBindListeners()
        {
            base.UnBindListeners();
            _btnContinue?.onClick.RemoveListener(OnClosePopup);
        }
    }
}
