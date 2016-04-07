using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Common
{
    public class InputState
    {
        public KeyboardState PreviousKeyboardState { get; set; }
        public KeyboardState CurrentKeyboardState { get; set; }

        public MouseState PreviousMouseState { get; set; }
        public MouseState CurrentMouseState { get; set; }

        public bool LeftClick()
        {
            return PreviousMouseState.LeftButton == ButtonState.Pressed && CurrentMouseState.LeftButton == ButtonState.Released;
        }

        public bool RightClick()
        {
            return PreviousMouseState.RightButton == ButtonState.Pressed && CurrentMouseState.RightButton == ButtonState.Released;
        }

        public bool KeyPressed(Keys key)
        {
            return PreviousKeyboardState.IsKeyDown(key) && CurrentKeyboardState.IsKeyUp(key);
        }
    }
}
