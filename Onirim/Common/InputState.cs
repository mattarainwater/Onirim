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
    }
}
