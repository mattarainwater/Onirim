using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public class DiscardLocation : BaseCommand, ILocationable
    {
        public Card Location { get; set; }

        public override void Execute(GameState gameState)
        {
            gameState.Hand.Remove(Location);
            gameState.DiscardPile.Add(Location);
            if((CardSymbolEnum)Location.Properties["Symbol"] == CardSymbolEnum.Key)
            {
                NextCommand = new Prophecy();
            }
            else
            {
                NextCommand = new Draw();
            }
        }
    }
}
