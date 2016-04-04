using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public class HandleDoor : BaseCommand
    {
        private readonly Card _door;

        public HandleDoor(Card door)
        {
            _door = door;
        }

        public override void Execute(GameState gameState)
        {
            gameState.MainDeck.Remove(_door);
            gameState.Limbo.Add(_door);
            NextCommand = new Draw();
        }
    }
}
