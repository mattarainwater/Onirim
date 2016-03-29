using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Model
{
    public class Card
    {
        public Card(Texture2D front, Texture2D back)
        {
            Front = front;
            Back = back;
        }

        public Card(Texture2D front, Texture2D back, Dictionary<string, object> properties)
            : this(front, back)
        {
            Properties = properties;
        }

        public Texture2D Front { get; set; }
        public Texture2D Back { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }
}
