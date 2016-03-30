using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Model
{
    public class Card
    {
        public Guid Id { get; set; }

        public Card()
        {
            Id = Guid.NewGuid();
        }

        public Card(Texture2D front, Texture2D back)
            : this()
        {
            Front = front;
            Back = back;
        }

        public Card(Texture2D front, Texture2D back, Dictionary<string, object> properties)
            : this(front, back)
        {
            Properties = properties;
        }

        public List<Card> Clone(int count)
        {
            var toReturn = new List<Card>();

            for(var i = 0; i < count; i++)
            {
                toReturn.Add(new Card(Front, Back, Properties));
            }

            return toReturn;
        }

        public Texture2D Front { get; set; }
        public Texture2D Back { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }
}
