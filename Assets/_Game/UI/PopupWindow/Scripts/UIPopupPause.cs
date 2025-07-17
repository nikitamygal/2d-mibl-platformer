using SoloGames.Managers;
using UnityEngine;
using UnityEngine.UI;


namespace SoloGames.UI
{
    public class UIPopupPause : UIPopup
    {
        [SerializeField] private Button _btnContinue;

        public override void Show()
        {
            base.Show();
            GameplayManager.Instance.Pause();
        }

        public override void Hide()
        {
            base.Hide();
            GameplayManager.Instance.UnPause();
        }

        public override void OnClosePopup()
        {
            base.OnClosePopup();
            GameplayManager.Instance.UnPause();
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
