﻿using Onirim.Model;
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
            NextCommand = new Draw();
        }
    }
}