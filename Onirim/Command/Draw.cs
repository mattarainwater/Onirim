using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public class Draw : BaseCommand
    {
        public override void Execute(GameModel gameState)
        {
            var cardToDraw = gameState.MainDeck.FirstOrDefault();
            if (cardToDraw != null)
            {
                if (cardToDraw.Type == CardTypeEnum.Location)
                {
                    gameState.Hand.Add(cardToDraw);
                    gameState.MainDeck.Remove(cardToDraw);
                    if(gameState.Hand.Count == 5)
                    {
                        NextCommand = new Shuffle();
                    }
                    else
                    {
                        NextCommand = new Draw();
                    }
                }
                else if (cardToDraw.Type == CardTypeEnum.Door)
                {
                    NextCommand = new HandleDoor(cardToDraw);
                }
                else if (cardToDraw.Type == CardTypeEnum.Nightmare)
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
