using SoloGames.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace SoloGames.UI
{
    public class UIPopup : MonoBehaviour, IPopup
    {
        [SerializeField] private Button _btnClose;
        [SerializeField] private Button _btnQuit;

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void OnClosePopup()
        {
            UIPopupManager.Instance.HideCurrentPopup();
        }

        public virtual void OnQuit()
        {
            SceneManager.LoadScene("MainMenu"); // TODO change to service
        }

        protected virtual void BindListeners()
        {
            _btnClose?.onClick.AddListener(OnClosePopup);
            _btnQuit?.onClick.AddListener(OnQuit);
        }

        protected virtual void UnBindListeners()
        {
            _btnClose?.onClick.RemoveListener(OnClosePopup);
            _btnQuit?.onClick.RemoveListener(OnQuit);
        }

        private void OnEnable()
        {
            BindListeners();
        }

        private void OnDisable()
        {
            UnBindListeners();
        }
    }
}
