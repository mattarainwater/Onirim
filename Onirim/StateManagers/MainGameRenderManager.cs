using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Onirim.Command;
using Onirim.ContentManagers;
using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.StateManagers
{
    public class MainGameRenderManager
    {
        public MainGameRenderManager()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight, GameModel model, List<Button> buttons)
        {
            spriteBatch.Begin();
            DrawLimbo(spriteBatch, model, screenWidth, screenHeight);
            DrawDeck(spriteBatch, model, screenWidth, screenHeight);
            DrawPlayArea(spriteBatch, model, screenWidth, screenHeight);
            if(model.DrawnDoor != null)
            {
                DrawDrawnDoorAndKey(spriteBatch, model, screenWidth, screenHeight, buttons);
            }
            else if(model.ProphecyArea.Any())
            {
                DrawProphecyArea(spriteBatch, model, screenWidth, screenHeight, buttons);
            }
            else
            {
                DrawHand(spriteBatch, model, screenWidth, screenHeight, buttons);
            }
            DrawDiscardPile(spriteBatch, model, screenWidth, screenHeight);
            DrawDoors(spriteBatch, model, screenWidth, screenHeight);
            spriteBatch.End();
        }

        private void DrawDrawnDoorAndKey(SpriteBatch spriteBatch, GameModel state, int screenWidth, int screenHeight, List<Button> buttons)
        {
            var door = state.DrawnDoor;
            var key = state.Hand.First(x => x.Symbol == CardSymbolEnum.Key && x.Color == door.Color);

            var xPos = 175;
            var yPos = (screenHeight - 750);

            spriteBatch.Draw(door.Front, new Rectangle(175, yPos, 100, 175), Color.White);
            spriteBatch.Draw(key.Front, new Rectangle(175, yPos + 300, 100, 175), Color.White);
            for(var i = 0; i < buttons.Count; i++)
            {
                buttons[i].Draw(spriteBatch, new Rectangle(175 + i * 55, yPos + 500, 50, 175 / 2));
            }
        }

        private void DrawProphecyArea(SpriteBatch spriteBatch, GameModel state, int screenWidth, int screenHeight, List<Button> buttons)
        {
            var prophecy = state.ProphecyArea.ToArray();
            var xPos = (screenWidth - 700) / 2;
            var yPos = (screenHeight - 400);

            for (int i = 0; i < prophecy.Count(); i++)
            {
                var front = prophecy[i].Front;
                spriteBatch.Draw(front, new Rectangle(xPos + 150 * i, yPos, 100, 175), Color.White);
                var buttonForLocation = buttons.Where(x => ((ILocationable)x.Command).Location.Id == prophecy[i].Id);
                DrawButtons(spriteBatch, buttonForLocation, xPos + 150 * i, yPos + 200);
            }
        }

        private void DrawLimbo(SpriteBatch spriteBatch, GameModel state, int screenWidth, int screenHeight)
        {
            var limbo = state.Limbo.ToArray();
            var xPos = 300;
            var yPos = 50;
            for (int i = 0; i < limbo.Count(); i++)
            {
                var front = limbo[i].Front;
                var yPosFactor = (int)Math.Floor(i / 23d) * 175 + yPos;

                spriteBatch.Draw(front, new Rectangle(xPos + 75 * (i % 23), yPosFactor, 100, 175), Color.White);
            }
        }

        private void DrawDiscardPile(SpriteBatch spriteBatch, GameModel state, int screenWidth, int screenHeight)
        {
            if (state.DiscardPile.Any())
            {
                var front = state.DiscardPile.Last().Front;
                spriteBatch.Draw(front, new Rectangle(50, 50, 100, 175), Color.White);
            }
        }

        private void DrawPlayArea(SpriteBatch spriteBatch, GameModel state, int screenWidth, int screenHeight)
        {
            var playArea = state.PlayArea.ToArray();
            var xPos = 50;
            var yPos = 250;
            for (int i = 0; i < playArea.Count(); i++)
            {
                var front = playArea[i].Front;
                var yPosFactor = (int)Math.Floor(i / 23d) * 175 + yPos;

                spriteBatch.Draw(front, new Rectangle(xPos + 75 * (i % 23), yPosFactor, 100, 175), Color.White);
            }
        }

        private void DrawDeck(SpriteBatch spriteBatch, GameModel state, int screenWidth, int screenHeight)
        {
            if(state.MainDeck.Any())
            {
                var back = state.MainDeck.First().Back;
                spriteBatch.Draw(back, new Rectangle(175, 50, 100, 175), Color.White);
            }
        }

        private void DrawHand(SpriteBatch spriteBatch, GameModel state, int screenWidth, int screenHeight, List<Button> buttons)
        {
            var hand = state.Hand.ToArray();
            var xPos = (screenWidth - 700) / 2;
            var yPos = (screenHeight - 400);
            for (int i = 0; i < hand.Count(); i++)
            {
                var front = hand[i].Front;
                spriteBatch.Draw(front, new Rectangle(xPos + 150 * i, yPos, 100, 175), Color.White);
                var buttonForLocation = buttons.Where(x => ((ILocationable)x.Command).Location.Id == hand[i].Id);
                DrawButtons(spriteBatch, buttonForLocation, xPos + 150 * i, yPos + 200);
            }
        }

        private void DrawButtons(SpriteBatch spriteBatch, IEnumerable<Button> buttonForLocation, int xPos, int yPos)
        {
            foreach (var button in buttonForLocation)
            {
                button.Draw(spriteBatch, new Rectangle(xPos, yPos, 50, 175 / 2));
                xPos += 55;
            }
        }

        private void DrawDoors(SpriteBatch spriteBatch, GameModel state, int screenWidth, int screenHeight)
        {
            var doors = state.Doors.ToArray();
            var xPos = 300;
            var yPos = 50;
            for (int i = 0; i < doors.Count(); i++)
            {
                var front = doors[i].Front;
                var yPosFactor = (int)Math.Floor(i / 23d) * 175 + yPos;

                spriteBatch.Draw(front, new Rectangle(xPos + 75 * (i % 23), yPosFactor, 100, 175), Color.White);
            }
        }
    }
}
