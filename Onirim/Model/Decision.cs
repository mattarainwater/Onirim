using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Onirim.Command;

namespace Onirim.Model
{
    public class Decision
    {
        public List<BaseCommand> Options { get; set; }
    }
}
