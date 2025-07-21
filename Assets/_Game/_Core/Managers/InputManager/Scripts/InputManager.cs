using System;
using UnityEngine;

namespace SoloGames.Managers
{
    public class InputManager
    {
        public virtual Vector2 PrimaryMovement { get { return _primaryMovement; } }

        protected Vector2 _primaryMovement = Vector2.zero;

        public virtual void SetHorizontalMovement(float horizontalInput)
        {
            _primaryMovement.x = horizontalInput;
        }

    }
}
