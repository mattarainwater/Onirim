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

        public override void Execute(GameModel gameState)
        {
            // draw card
            var card = gameState.MainDeck.First();

            // if location, add to hand
            if (card.Type == CardTypeEnum.Location)
            {
                gameState.MainDeck.Remove(card);
                gameState.Hand.Add(card);
            }
            // else, add to limbo
            else
            {
                gameState.MainDeck.Remove(card);
                gameState.Limbo.Add(card);
            }

            // if hand == 5 next command shuffle
            if(gameState.Hand.Count() == 5)
            {
                NextCommand = new Shuffle();
            }
            // else next command drawlocations
            else
            {
                NextCommand = new DrawLocations();
            }
        }
    }
}
