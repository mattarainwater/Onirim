using Onirim.Manager;
using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public class DrawLocations : BaseCommand
    {
        public DrawLocations()
        {
        }

        public override void Execute(GameState gameState)
        {
            while(gameState.Hand.Count() < 5 && gameState.MainDeck.Any())
            {
                var nextLocation = gameState.MainDeck.FirstOrDefault(c => c.GetType() == typeof(Location));
                if(nextLocation != null)
                {
                    gameState.MainDeck.Remove(nextLocation);
                    gameState.Hand.Add(nextLocation);
                }
                else
                {
                    break;
                }
            }

            NextCommand = new Shuffle();
        }
    }
}
