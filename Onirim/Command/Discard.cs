using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public class Discard : BaseCommand, ILocationable
    {
        public Card Location { get; set; }

        public override void Execute(GameState gameState)
        {
            gameState.ProphecyArea.Clear();
            gameState.MainDeck.Remove(Location);
            gameState.DiscardPile.Add(Location);
            NextCommand = new Draw();
        }
    }
}
