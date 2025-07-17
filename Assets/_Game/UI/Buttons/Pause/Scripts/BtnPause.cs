using SoloGames.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace SoloGames.UI
{
    public class BtnPause : MonoBehaviour
    {
        private Button _btn;

        private void Awake()
        {
            _btn = GetComponent<Button>();
        }

        public void OnPause()
        {
            GameplayManager.Instance.Pause();
        }

        private void OnEnable()
        {
            _btn?.onClick.AddListener(OnPause);
        }

        private void OnDisable()
        {
            _btn?.onClick.RemoveListener(OnPause);
        }

    }
}
