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
                    NextCommand = new Shuffle();
                }
                else if ((CardTypeEnum)cardToDraw.Properties["Type"] == CardTypeEnum.Door)
                {
                    NextCommand = new HandleDoor(cardToDraw);
                }
                else if ((CardTypeEnum)cardToDraw.Properties["Type"] == CardTypeEnum.Nightmare)
                {
                    NextCommand = new HandleNightmare(cardToDraw);
                }
            }
            else
            {
                NextCommand = new Lose();
            }
        }
    }
}
