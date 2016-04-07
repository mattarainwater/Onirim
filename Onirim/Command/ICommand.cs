using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public interface ICommand
    {
        void Execute(GameModel gameState);
    }
}
