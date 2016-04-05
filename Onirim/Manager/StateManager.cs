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
            Buttons = new List<Button>();
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
            Buttons = new List<Button>();

            if(State.ProphecyArea.Any())
            {

            }
            else
            {
                var hand = State.Hand;
                var actions = new List<BaseCommand>();
                actions.AddRange(hand.Select(x => new PlayLocation() { Location = x }));
                actions.AddRange(hand.Select(x => new DiscardLocation() { Location = x }));
                var playActions = actions.Where(x => x is PlayLocation);
                var discardActions = actions.Where(x => x is DiscardLocation);

                Buttons.AddRange(playActions.Select(x => ToPlayButton((PlayLocation)x)));
                Buttons.AddRange(discardActions.Select(x => ToDiscardButton((DiscardLocation)x)));
            }
        }

        private Button ToDiscardButton(DiscardLocation command)
        {
            return new Button
            {
                Command = command,
                Texture = ArtManager.Discard
            };
        }

        private Button ToPlayButton(PlayLocation command)
        {
            return new Button
            {
                Command = command,
                Texture = ArtManager.Play
            };
        }
    }
}
