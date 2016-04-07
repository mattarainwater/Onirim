using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Model
{
    public class Card
    {

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

        public Card(Texture2D front, Texture2D back, CardTypeEnum type, CardColorEnum color = CardColorEnum.None, CardSymbolEnum symbol = CardSymbolEnum.None)
            : this(front, back)
        {
            Type = type;
            Color = color;
            Symbol = symbol;
        }

        public List<Card> Clone(int count)
        {
            var toReturn = new List<Card>();

            for(var i = 0; i < count; i++)
            {
                toReturn.Add(new Card(Front, Back, Type, Color, Symbol));
            }

            return toReturn;
        }

        public Guid Id { get; set; }
        public Texture2D Front { get; set; }
        public Texture2D Back { get; set; }
        public CardTypeEnum Type { get; set; }
        public CardColorEnum Color { get; set; }
        public CardSymbolEnum Symbol { get; set; }
    }
}
