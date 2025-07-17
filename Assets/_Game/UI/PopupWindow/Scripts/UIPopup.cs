using UnityEngine;
using UnityEngine.UI;


namespace SoloGames.UI
{
    public class UIPopup : MonoBehaviour
    {
        [SerializeField] private Button _btnClose;

        public void OnClosePopup()
        {
        }

        private void OnEnable()
        {
            _btnClose?.onClick.AddListener(OnClosePopup);
        }

        private void OnDisable()
        {
            _btnClose?.onClick.RemoveListener(OnClosePopup);
        }
    }
}
