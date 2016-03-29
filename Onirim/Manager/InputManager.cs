using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Onirim.Command;
using Onirim.Model;

namespace Onirim.Manager
{
    public class InputManager
    {
        private KeyboardState PreviousKeyboardState { get; set; }
        private MouseState PreviousMouseState { get; set; }
        private StateManager StateManager { get; set; }

        public List<Button> Buttons { get; set; }

        public InputManager(StateManager stateManager)
        {
            StateManager = stateManager;
        }

        public void HandleInput(KeyboardState keyboardState, MouseState mouseState)
        {
            if(PreviousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
            {
                foreach (var button in StateManager.Buttons)
                {
                    if (button.BeenClicked(mouseState))
                    {
                        StateManager.ExecuteCommand(button.Command);
                    }
                }
            }

            PreviousKeyboardState = keyboardState;
            PreviousMouseState = mouseState;
        }
    }
}
