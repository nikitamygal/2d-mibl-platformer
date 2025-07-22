using SoloGames.Tools;
using UnityEngine;
using UnityEngine.EventSystems;


namespace SoloGames.UI
{
    public enum ButtonStates { Off, ButtonDown, ButtonUp }

    public class BtnControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public StateMachine<ButtonStates> State { get; protected set; }

        public virtual bool IsDown => State.CurrentState == ButtonStates.ButtonDown;
        public virtual bool IsUp => State.CurrentState == ButtonStates.ButtonUp;
        public virtual bool IsOff => State.CurrentState == ButtonStates.Off;

        protected virtual void Awake()
        {
            State = new StateMachine<ButtonStates>();
            State.ChangeState(ButtonStates.Off);
        }

        public virtual void OnButtonDown()
        {
            State.ChangeState(ButtonStates.ButtonDown);
        }

        public virtual void OnButtonUp()
        { 
            State.ChangeState(ButtonStates.ButtonUp);
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
