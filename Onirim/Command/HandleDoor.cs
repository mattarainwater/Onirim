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

        public override void Execute(GameModel gameState)
        {
            gameState.MainDeck.Remove(_door);
            if(gameState.Hand.Any(x => x.Symbol == CardSymbolEnum.Key && x.Color == _door.Color))
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
