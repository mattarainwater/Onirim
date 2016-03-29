using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Command
{
    public interface ILocationable
    {
        Card Location { get; set; }
    }
}
