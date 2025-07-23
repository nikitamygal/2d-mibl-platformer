using SoloGames.Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace SoloGames.UI
{
    public class UILevelCompleted : UIPopup
    {
        [SerializeField] private Button _btnNext;

        private SceneLoader _sceneLoader;

        [Inject]
        public void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public void OnNextLevel()
        {
            _sceneLoader.LoadScene(Scenes.GamePlay);
        }

        protected override void BindListeners()
        {
            base.BindListeners();
            _btnNext?.onClick.AddListener(OnNextLevel);
        }

        protected override void UnBindListeners()
        {
            base.UnBindListeners();
            _btnNext?.onClick.RemoveListener(OnNextLevel);
        }
    }
}
