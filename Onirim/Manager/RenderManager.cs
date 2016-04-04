using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Onirim.Command;
using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Manager
{
    public class RenderManager
    {
        private StateManager StateManager { get; set; }

        public RenderManager(SpriteBatch spriteBatch, StateManager stateManager)
        {
            SpriteBatch = spriteBatch;
            StateManager = stateManager;
        }

        public SpriteBatch SpriteBatch { get; set; }

        public void Draw(int screenWidth, int screenHeight)
        {
            SpriteBatch.Begin();
            DrawHand(StateManager.State, screenWidth, screenHeight, StateManager.Buttons);
            DrawLimbo(StateManager.State, screenWidth, screenHeight);
            DrawDeck(StateManager.State, screenWidth, screenHeight);
            DrawPlayArea(StateManager.State, screenWidth, screenHeight);
            DrawDiscardPile(StateManager.State, screenWidth, screenHeight);
            DrawDoors(StateManager.State, screenWidth, screenHeight);
            SpriteBatch.End();
        }

        private void DrawLimbo(GameState state, int screenWidth, int screenHeight)
        {
            var limbo = state.Limbo.ToArray();
            var xPos = 300;
            var yPos = 50;
            for (int i = 0; i < limbo.Count(); i++)
            {
                var front = limbo[i].Front;
                var yPosFactor = (int)Math.Floor(i / 23d) * 175 + yPos;

                SpriteBatch.Draw(front, new Rectangle(xPos + 75 * (i % 23), yPosFactor, 100, 175), Color.White);
            }
        }

        private void DrawDiscardPile(GameState state, int screenWidth, int screenHeight)
        {
            if (state.DiscardPile.Any())
            {
                var front = state.DiscardPile.Last().Front;
                SpriteBatch.Draw(front, new Rectangle(50, 50, 100, 175), Color.White);
            }
        }

        private void DrawPlayArea(GameState state, int screenWidth, int screenHeight)
        {
            var playArea = state.PlayArea.ToArray();
            var xPos = 50;
            var yPos = 250;
            for (int i = 0; i < playArea.Count(); i++)
            {
                var front = playArea[i].Front;
                var yPosFactor = (int)Math.Floor(i / 23d) * 175 + yPos;

                SpriteBatch.Draw(front, new Rectangle(xPos + 75 * (i % 23), yPosFactor, 100, 175), Color.White);
            }
        }

        private void DrawDeck(GameState state, int screenWidth, int screenHeight)
        {
            if(state.MainDeck.Any())
            {
                var back = state.MainDeck.First().Back;
                SpriteBatch.Draw(back, new Rectangle(175, 50, 100, 175), Color.White);
            }
        }

        private void DrawHand(GameState state, int screenWidth, int screenHeight, List<Button> buttons)
        {
            var hand = state.Hand.ToArray();
            var xPos = (screenWidth - 700) / 2;
            var yPos = (screenHeight - 400);
            for (int i = 0; i < hand.Count(); i++)
            {
                var front = hand[i].Front;
                SpriteBatch.Draw(front, new Rectangle(xPos + 150 * i, yPos, 100, 175), Color.White);
                var buttonForLocation = buttons.Where(x => ((ILocationable)x.Command).Location.Id == hand[i].Id);
                DrawButtons(buttonForLocation, xPos + 150 * i, yPos + 200);
            }
        }

        private void DrawButtons(IEnumerable<Button> buttonForLocation, int xPos, int yPos)
        {
            foreach (var button in buttonForLocation)
            {
                button.HitBox = new Rectangle(xPos, yPos, 50, 175 / 2);
                SpriteBatch.Draw(button.Texture, button.HitBox, Color.White);
                xPos += 55;
            }
        }

        private void DrawDoors(GameState state, int screenWidth, int screenHeight)
        {
            var doors = state.Doors.ToArray();
            var xPos = 300;
            var yPos = 50;
            for (int i = 0; i < doors.Count(); i++)
            {
                var front = doors[i].Front;
                var yPosFactor = (int)Math.Floor(i / 23d) * 175 + yPos;

                SpriteBatch.Draw(front, new Rectangle(xPos + 75 * (i % 23), yPosFactor, 100, 175), Color.White);
            }
        }
    }
}
