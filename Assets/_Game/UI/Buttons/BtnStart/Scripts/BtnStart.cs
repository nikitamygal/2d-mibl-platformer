using SoloGames.Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SoloGames.UI
{
    [RequireComponent(typeof(Button))]
    public class BtnStart : MonoBehaviour
    {
        private Button _btn;
        private SceneLoader _sceneLoader;

        [Inject]
        public void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            _btn = GetComponent<Button>();
            ProjectContext.Instance.Container.Inject(this);
        }

        public void OnStart()
        {
            _sceneLoader.LoadScene(Scenes.GamePlay);
        }

        private void OnEnable()
        {
            _btn?.onClick.AddListener(OnStart);
        }

        private void OnDisable()
        {
            _btn?.onClick.RemoveListener(OnStart);
        }

    }
}
