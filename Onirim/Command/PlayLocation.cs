using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public class PlayLocation : BaseCommand, ILocationable
    {
        public Card Location { get; set; }

        public override void Execute(GameModel gameState)
        {
            gameState.PlayArea.Add(Location);
            gameState.Hand.Remove(Location);
            if(gameState.PlayArea.Count() >= 3)
            {
                var reversePlayArea = gameState.PlayArea.Reverse<Card>();
                var lastThreeGrouped = reversePlayArea.Take(3).GroupBy(x => x.Properties["Color"]);
                if(lastThreeGrouped.Count() == 1)
                {
                    NextCommand = new GainDoor((CardColorEnum)lastThreeGrouped.First().Key);
                }
                else
                {
                    NextCommand = new Draw();
                }
            }
            else
            {
                NextCommand = new Draw();
            }
        }
    }
}
