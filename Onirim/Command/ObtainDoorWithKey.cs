using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public class ObtainDoorWithKey : BaseCommand, ILocationable
    {
        public Card Location { get; set; }

        public override void Execute(GameModel gameState)
        {
            gameState.Hand.Remove(Location);
            gameState.DiscardPile.Add(Location);
            gameState.Doors.Add(gameState.DrawnDoor);
            gameState.DrawnDoor = null;
            NextCommand = new Draw();
        }
    }
}
