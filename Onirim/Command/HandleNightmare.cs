using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public class HandleNightmare : BaseCommand
    {
        private readonly Card _nightmare;

        public HandleNightmare(Card nightmare)
        {
            _nightmare = nightmare;
        }

        public override void Execute(GameModel gameState)
        {
            gameState.MainDeck.Remove(_nightmare);
            gameState.DiscardPile.Add(_nightmare);
            NextCommand = new Draw();
        }
    }
}
