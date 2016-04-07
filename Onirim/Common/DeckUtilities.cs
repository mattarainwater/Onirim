using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Common
{
    public static class DeckUtilities
    {
        public static void ShuffleCards(IList<Card> cards)
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}
