using Onirim.Manager;
using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public class PlayLocation : BaseCommand
    {
        public Card Location { get; set; }

        public override void Execute(GameState gameState)
        {
            gameState.PlayArea.Add(Location);
            gameState.Hand.Remove(Location);
            NextCommand = new Draw();
        }
    }
}
