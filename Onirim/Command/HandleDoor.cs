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
            if(gameState.Hand.Any(x => (CardSymbolEnum)x.Properties["Symbol"] == CardSymbolEnum.Key && (CardColorEnum)x.Properties["Color"] == (CardColorEnum)_door.Properties["Color"]))
            {
                gameState.DrawnDoor = _door;
            }
            else
            {
                gameState.Limbo.Add(_door);
                NextCommand = new Draw();
            }
        }
    }
}
