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
                if ((CardTypeEnum)cardToDraw.Properties["Type"] == CardTypeEnum.Location)
                {
                    gameState.Hand.Add(cardToDraw);
                    gameState.MainDeck.Remove(cardToDraw);
                }
                else if ((CardTypeEnum)cardToDraw.Properties["Type"] == CardTypeEnum.Door)
                {
                    if(gameState.MainDeck.All(x => (CardTypeEnum)x.Properties["Type"] == CardTypeEnum.Door))
                    {
                        NextCommand = new Lose();
                    }
                    else
                    {
                        NextCommand = new Shuffle(new Draw());
                    }
                }
                else if ((CardTypeEnum)cardToDraw.Properties["Type"] == CardTypeEnum.Nightmare)
                {
                    gameState.DiscardPile.Add(cardToDraw);
                    gameState.MainDeck.Remove(cardToDraw);
                    NextCommand = new Draw();
                }
            }
            else
            {
                NextCommand = new Lose();
            }
        }
    }
}
