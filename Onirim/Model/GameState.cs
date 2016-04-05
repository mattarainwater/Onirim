using Onirim.ContentManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Model
{
    public class GameState
    {
        public GameState()
        {
            MainDeck = DeckManager.GetBaseDeck();
            Limbo = new List<Card>();
            DiscardPile = new List<Card>();
            PlayArea = new List<Card>();
            Hand = new List<Card>();
            Doors = new List<Card>();
            ProphecyArea = new List<Card>();
        }

        public void Reset()
        {
            MainDeck = DeckManager.GetBaseDeck();
            Limbo = new List<Card>();
            DiscardPile = new List<Card>();
            PlayArea = new List<Card>();
            Hand = new List<Card>();
            Doors = new List<Card>();
            ProphecyArea = new List<Card>();
        }

        public List<Card> MainDeck { get; set; }
        public List<Card> Limbo { get; set; }
        public List<Card> Doors { get; set; }
        public List<Card> DiscardPile { get; set; }
        public List<Card> PlayArea { get; set; }
        public List<Card> Hand { get; set; }
        public List<Card> ProphecyArea { get; set; }
        public Card DrawnDoor { get; set; }
    }
}
