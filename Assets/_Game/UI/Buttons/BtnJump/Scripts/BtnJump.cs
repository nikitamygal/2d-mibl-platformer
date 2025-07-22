using SoloGames.Managers;
using Zenject;

namespace SoloGames.UI
{
    public class BtnJump : BtnControl
    {
        private InputManager _inputManager;

        [Inject]
        public void Construct(InputManager inputManager)
        {
            _inputManager = inputManager;
        }

        protected override void Awake()
        {
            base.Awake();
            _inputManager.AddControlButton(ControlButtons.JumpButton, this);
        }

    }
}
