using System;
using Onirim.Model;

namespace Onirim.Command
{
    public class Reset : BaseCommand
    {
        public override void Execute(GameModel gameState)
        {
            gameState.Reset();
            NextCommand = new Shuffle(new DrawLocations());
        }
    }
}