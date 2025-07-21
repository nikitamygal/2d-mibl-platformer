using UnityEngine;
using UnityEngine.EventSystems;


namespace SoloGames.UI
{
    public enum ButtonStates { Off, ButtonDown, ButtonUp }

    public class BtnControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public virtual void OnButtonDown()
        { 
        }

        public virtual void OnButtonUp()
        { 
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnButtonDown();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnButtonUp();
        }
    }
}
