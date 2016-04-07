using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Onirim.Command;
using Onirim.Model;
using Onirim.Common;

namespace Onirim.StateManagers
{
    public class MainGameInputManager
    {
        public MainGameInputManager()
        {
        }

        public BaseCommand HandleInput(InputState inputState, List<Button> buttons)
        {
            if(inputState.LeftClick())
            {
                foreach (var button in buttons)
                {
                    if (button.BeenClicked(inputState.CurrentMouseState))
                    {
                        return button.Command;
                    }
                }
            }
            return null;
        }
    }
}
