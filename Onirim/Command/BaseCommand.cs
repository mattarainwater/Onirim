using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public abstract class BaseCommand : ICommand
    {
        public BaseCommand NextCommand { get; set; }
        public abstract void Execute(GameModel gameState);
    }
}
