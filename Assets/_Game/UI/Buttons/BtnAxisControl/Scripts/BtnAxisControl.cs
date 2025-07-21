using SoloGames.Managers;
using UnityEngine;

namespace SoloGames.UI
{

    public class BtnAxisControl : BtnControl
    {
        [SerializeField] private float _axisValue;

        private InputManager _inputManager => InputManager.Instance; // TODO temp

        public override void OnButtonDown()
        {
            base.OnButtonDown();
            _inputManager.SetHorizontalMovement(_axisValue);
        }
        
        public override void OnButtonUp()
        { 
            base.OnButtonUp();
            _inputManager.SetHorizontalMovement(0);
        }

    }
}
