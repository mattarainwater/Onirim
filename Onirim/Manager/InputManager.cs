using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Onirim.Manager
{
    public class InputManager
    {
        private KeyboardState PreviousKeyboardState { get; set; }
        private MouseState PreviousMouseState { get; set; }
        private StateManager StateManager { get; set; }

        public InputManager(StateManager stateManager)
        {
            StateManager = stateManager;
        }

        public void HandleInput(KeyboardState keyboardState, MouseState mouseState)
        {
            var availableCommands = StateManager.GetAvailableActions();

            if (PreviousKeyboardState.IsKeyUp(Keys.D1) && keyboardState.IsKeyDown(Keys.D1) && availableCommands.Count > 0)
            {
                StateManager.ExecuteCommand(availableCommands[0]);
            }
            if (PreviousKeyboardState.IsKeyUp(Keys.D2) && keyboardState.IsKeyDown(Keys.D2) && availableCommands.Count > 1)
            {
                StateManager.ExecuteCommand(availableCommands[1]);
            }
            if (PreviousKeyboardState.IsKeyUp(Keys.D3) && keyboardState.IsKeyDown(Keys.D3) && availableCommands.Count > 2)
            {
                StateManager.ExecuteCommand(availableCommands[2]);
            }
            if (PreviousKeyboardState.IsKeyUp(Keys.D4) && keyboardState.IsKeyDown(Keys.D4) && availableCommands.Count > 3)
            {
                StateManager.ExecuteCommand(availableCommands[3]);
            }
            if (PreviousKeyboardState.IsKeyUp(Keys.D5) && keyboardState.IsKeyDown(Keys.D5) && availableCommands.Count > 4)
            {
                StateManager.ExecuteCommand(availableCommands[4]);
            }

            PreviousKeyboardState = keyboardState;  // set the new state as the old state for next time
        }
    }
}
