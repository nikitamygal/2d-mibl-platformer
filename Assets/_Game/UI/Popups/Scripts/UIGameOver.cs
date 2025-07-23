using SoloGames.Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace SoloGames.UI
{
    public class UIGameOver : UIPopup
    {
        [SerializeField] private Button _btnReplay;

        private SceneLoader _sceneLoader;

        [Inject]
        public void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public void OnReplay()
        {
            _sceneLoader.LoadScene(Scenes.GamePlay);
        }

        protected override void BindListeners()
        {
            base.BindListeners();
            _btnClose?.onClick.AddListener(OnReplay);
            _btnReplay?.onClick.AddListener(OnReplay);
        }

        protected override void UnBindListeners()
        {
            base.UnBindListeners();
            _btnClose?.onClick.RemoveListener(OnReplay);
            _btnReplay?.onClick.RemoveListener(OnReplay);
        }
    }
}
