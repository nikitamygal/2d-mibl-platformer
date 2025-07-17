using SoloGames.Managers;
using UnityEngine;
using UnityEngine.UI;


namespace SoloGames.UI
{
    public class UILevelCompleted : UIPopup
    {
        [SerializeField] private Button _btnNext;

        public void OnNextLevel()
        { 
            Debug.Log("OnNextLevel click");
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
