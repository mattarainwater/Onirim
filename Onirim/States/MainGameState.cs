using Microsoft.Xna.Framework.Graphics;
using Onirim.Command;
using Onirim.ContentManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Onirim.Common;
using Onirim.Model;
using Onirim.StateManagers;

namespace Onirim.States
{
    public class MainGameState : IGameState
    {
        public GameModel Model { get; set; }
        public List<Button> Buttons { get; set; }

        private MainGameRenderManager _renderManager;
        private MainGameInputManager _inputManager;

        public MainGameState()
        {
            Model = new GameModel();
            Buttons = new List<Button>();
            _renderManager = new MainGameRenderManager();
            _inputManager = new MainGameInputManager();
        }

        public void OnEnter()
        {
            Model.Reset();
            ExecuteCommand(new Shuffle());
            ExecuteCommand(new DrawLocations());
        }

        public void OnExit()
        {
        }

        public void Update(InputState inputState)
        {
            var command = _inputManager.HandleInput(inputState, Buttons);
            if(command != null)
            {
                ExecuteCommand(command);
            }
        }

        public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            _renderManager.Draw(spriteBatch, screenWidth, screenHeight, Model, Buttons);
        }

        private void ExecuteCommand(BaseCommand command)
        {
            command.Execute(Model);
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

            if (Model.DrawnDoor != null)
            {
                var playDoor = new ObtainDoorWithKey() { Location = Model.Hand.First(x => x.Symbol == CardSymbolEnum.Key && x.Color == Model.DrawnDoor.Color) };
                var discardDoor = new PassOnDoor();
                Buttons.Add(ToButton(playDoor, ArtManager.Play));
                Buttons.Add(ToButton(discardDoor, ArtManager.Discard));
            }
            else if (Model.ProphecyArea.Any())
            {
                var prophecy = Model.ProphecyArea;
                var actions = new List<BaseCommand>();
                actions.AddRange(prophecy.Select(x => new Discard() { Location = x }));
                Buttons.AddRange(actions.Select(x => ToButton(x, ArtManager.Discard)));
            }
            else
            {
                var hand = Model.Hand;
                var lastPlayedCard = Model.PlayArea.LastOrDefault();
                var actions = new List<BaseCommand>();
                actions.AddRange(hand.Where(x => AbleToPlay(x, lastPlayedCard)).Select(x => new PlayLocation() { Location = x }));
                actions.AddRange(hand.Select(x => new DiscardLocation() { Location = x }));
                var playActions = actions.Where(x => x is PlayLocation);
                var discardActions = actions.Where(x => x is DiscardLocation);

                Buttons.AddRange(playActions.Select(x => ToButton(x, ArtManager.Play)));
                Buttons.AddRange(discardActions.Select(x => ToButton(x, ArtManager.Discard)));
            }
        }

        private bool AbleToPlay(Card cardInHand, Card lastPlayedCard)
        {
            return lastPlayedCard == null || lastPlayedCard.Symbol != cardInHand.Symbol;
        }

        private Button ToButton(BaseCommand command, Texture2D texture)
        {
            return new Button
            {
                Command = command,
                Texture = texture
            };
        }
    }
}
