﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Onirim.Model;

namespace Onirim.Command
{
    public class Lose : BaseCommand
    {
        public override void Execute(GameState gameState)
        {
            NextCommand = new Reset();
        }
    }
}
