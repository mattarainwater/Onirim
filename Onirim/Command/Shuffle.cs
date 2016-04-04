using Onirim.Manager;
using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public class Shuffle : BaseCommand
    {
        public Shuffle()
        {

        }

        public Shuffle(BaseCommand command)
        {
            NextCommand = command;
        }

        public override void Execute(GameState gameState)
        {
            gameState.MainDeck.AddRange(gameState.Limbo);
            gameState.Limbo.Clear();
            DeckUtilities.ShuffleCards(gameState.MainDeck);
        }
    }
}
