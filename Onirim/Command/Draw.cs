using Onirim.Manager;
using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public class Draw : BaseCommand
    {
        public override void Execute(GameState gameState)
        {
            var cardToDraw = gameState.MainDeck.FirstOrDefault();
            if (cardToDraw != null)
            {
                gameState.Hand.Add(cardToDraw);
                gameState.MainDeck.Remove(cardToDraw);
            }
        }
    }
}
