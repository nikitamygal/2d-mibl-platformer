using SoloGames.Managers;
using UnityEngine;
using Zenject;

namespace SoloGames.UI
{

    public class BtnAxisControl : BtnControl
    {
        [SerializeField] private float _axisValue;

        private InputManager _inputManager;

        [Inject]
        public void Construct(InputManager inputManager)
        {
            _inputManager = inputManager;
        }

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
