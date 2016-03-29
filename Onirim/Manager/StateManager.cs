using Onirim.Command;
using Onirim.ContentManagers;
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
        public List<Button> Buttons { get; set; }

        public void ExecuteCommand(BaseCommand command)
        {
            command.Execute(State);
            if (command.NextCommand != null)
            {
                ExecuteCommand(command.NextCommand);
            }
            else
            {
                SetAvailableActions();
            }
        }

        private void SetAvailableActions()
        {
            var hand = State.Hand;
            var actions = new List<BaseCommand>();
            actions.AddRange(hand.Select(x => new PlayLocation() { Location = x }));
            Buttons = actions.Select(ToButton).ToList();
        }

        private Button ToButton(BaseCommand command)
        {
            return new Button
            {
                Command = command,
                Texture = ArtManager.Play
            };
        }
    }
}
