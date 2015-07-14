using Onirim.Command;
using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Manager
{
    public class StateManager
    {
        public StateManager()
        {
            State = new GameState();
        }

        public GameState State { get; set; }

        public void ExecuteCommand(BaseCommand command)
        {
            command.Execute(State);
            if (command.NextCommand != null)
            {
                ExecuteCommand(command.NextCommand);
            }
        }

        public List<BaseCommand> GetAvailableActions()
        {
            return new List<BaseCommand>
            {
                new PlayLocation { Location = State.Hand[0] },
                new PlayLocation { Location = State.Hand[1] },
                new PlayLocation { Location = State.Hand[2] },
                new PlayLocation { Location = State.Hand[3] },
                new PlayLocation { Location = State.Hand[4] },
            };
        }
    }
}
