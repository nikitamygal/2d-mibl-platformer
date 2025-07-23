using SoloGames.Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace SoloGames.UI
{
    public class UIPopup : MonoBehaviour, IPopup
    {
        [SerializeField] protected Button _btnClose;
        [SerializeField] protected Button _btnQuit;

        private UIPopupManager _popupManager;
        private SceneLoader _sceneLoader;

        [Inject]
        public void Construct(UIPopupManager popupManager, SceneLoader sceneLoader)
        {
            _popupManager = popupManager;
            _sceneLoader = sceneLoader;
        }
        
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
            _popupManager?.HideCurrentPopup();
        }

        public virtual void OnQuit()
        {
            _sceneLoader?.LoadScene(Scenes.MainMenu);
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
