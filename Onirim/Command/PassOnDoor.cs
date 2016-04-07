using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public class PassOnDoor : BaseCommand
    {
        public override void Execute(GameModel gameState)
        {
            gameState.Limbo.Add(gameState.DrawnDoor);
            gameState.DrawnDoor = null;
            NextCommand = new Draw();
        }
    }
}
