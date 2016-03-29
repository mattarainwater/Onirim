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
            var hand = State.Hand;
            var actions = new List<BaseCommand>();
            actions.AddRange(hand.Select(x => new PlayLocation() { Location = x }));
            return actions;
        }
    }
}
