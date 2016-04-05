using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public class Prophecy : BaseCommand
    {
        public override void Execute(GameState gameState)
        {
            var topFiveOfDeck = gameState.MainDeck.Take(5);
            gameState.ProphecyArea.AddRange(topFiveOfDeck);
        }
    }
}
