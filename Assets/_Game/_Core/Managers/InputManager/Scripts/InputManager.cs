using System;
using System.Collections.Generic;
using SoloGames.UI;
using UnityEngine;

namespace SoloGames.Managers
{
    public enum ControlButtons { AxisLeftButton, AxisRightButton, JumpButton, FireButton }

    public class InputManager
    {
        public BtnControl JumpButton => _controlButtons.GetValueOrDefault(ControlButtons.JumpButton);
        public BtnControl FireButton => _controlButtons.GetValueOrDefault(ControlButtons.FireButton);
        public Vector2 PrimaryMovement => _primaryMovement;

        protected Vector2 _primaryMovement = Vector2.zero;
        protected Dictionary<ControlButtons, BtnControl> _controlButtons = new Dictionary<ControlButtons, BtnControl>();

        public virtual void SetHorizontalMovement(float horizontalInput)
        {
            _primaryMovement.x = horizontalInput;
        }

        public virtual void AddControlButton(ControlButtons buttonType, BtnControl button)
        {
            _controlButtons.Add(buttonType, button);
        }

    }
}
