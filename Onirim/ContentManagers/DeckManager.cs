﻿using Microsoft.Xna.Framework.Graphics;
using Onirim.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.ContentManagers
{
    public static class DeckManager
    {
        public static List<Card> GetBaseDeck()
        {
            // Read the file as one string.
            System.IO.StreamReader myFile =
               new System.IO.StreamReader("Content/Card/BaseGameDeck.txt");
            var cardsAsString = myFile.ReadToEnd();

            myFile.Close();

            return ConvertToCards(cardsAsString);
        }

        private static List<Card> ConvertToCards(string cardsAsString)
        {
            var cardsToReturn = new List<Card>();

            var lines = cardsAsString.Replace("\n", "").Split(new string[] { ";" }, StringSplitOptions.None);
            foreach(var line in lines)
            {
                if(!string.IsNullOrEmpty(line))
                {
                    var lineSeperated = line.Split(null);
                    var count = Int32.Parse(lineSeperated[lineSeperated.Count() - 1]);
                    var card = ToCard(lineSeperated.Take(lineSeperated.Count() - 1).ToArray());
                    cardsToReturn.AddRange(
                        card.Clone(count)
                    );
                }
            }

            return cardsToReturn;
        }

        private static Card ToCard(string[] cardAsString)
        {
            if(cardAsString.Count() == 1)
            {
                if(cardAsString[0] == "Nightmare")
                {
                    return new Card(ArtManager.Nightmare, ArtManager.DefaultBack, new Dictionary<string, object> {
                    { "Type", CardTypeEnum.Nightmare }
                });
                }
            }
            var color = (CardColorEnum)Enum.Parse(typeof(CardColorEnum), cardAsString[0]);
            if(cardAsString[1] == "Door")
            {
                Texture2D front = null;
                switch(color)
                {
                    case CardColorEnum.Blue:
                        front = ArtManager.BlueDoor;
                        break;
                    case CardColorEnum.Brown:
                        front = ArtManager.BrownDoor;
                        break;
                    case CardColorEnum.Green:
                        front = ArtManager.GreenDoor;
                        break;
                    case CardColorEnum.Red:
                        front = ArtManager.RedDoor;
                        break;
                }
                return new Card(front, ArtManager.DefaultBack, new Dictionary<string, object> {
                    { "Color", color },
                    { "Type", CardTypeEnum.Door }
                });
            }
            else
            {
                var symbol = (CardSymbolEnum)Enum.Parse(typeof(CardSymbolEnum), cardAsString[1]);

                Texture2D front = null;
                switch (color)
                {
                    case CardColorEnum.Blue:
                        switch (symbol)
                        {
                            case CardSymbolEnum.Key:
                                front = ArtManager.BlueKey;
                                break;
                            case CardSymbolEnum.Sun:
                                front = ArtManager.BlueSun;
                                break;
                            case CardSymbolEnum.Moon:
                                front = ArtManager.BlueMoon;
                                break;
                        }
                        break;
                    case CardColorEnum.Brown:
                        switch (symbol)
                        {
                            case CardSymbolEnum.Key:
                                front = ArtManager.BrownKey;
                                break;
                            case CardSymbolEnum.Sun:
                                front = ArtManager.BrownSun;
                                break;
                            case CardSymbolEnum.Moon:
                                front = ArtManager.BrownMoon;
                                break;
                        }
                        break;
                    case CardColorEnum.Green:
                        switch (symbol)
                        {
                            case CardSymbolEnum.Key:
                                front = ArtManager.GreenKey;
                                break;
                            case CardSymbolEnum.Sun:
                                front = ArtManager.GreenSun;
                                break;
                            case CardSymbolEnum.Moon:
                                front = ArtManager.GreenMoon;
                                break;
                        }
                        break;
                    case CardColorEnum.Red:
                        switch (symbol)
                        {
                            case CardSymbolEnum.Key:
                                front = ArtManager.RedKey;
                                break;
                            case CardSymbolEnum.Sun:
                                front = ArtManager.RedSun;
                                break;
                            case CardSymbolEnum.Moon:
                                front = ArtManager.RedMoon;
                                break;
                        }
                        break;
                }
                return new Card(front, ArtManager.DefaultBack, new Dictionary<string, object> {
                    { "Color", color },
                    { "Symbol", symbol },
                    { "Type", CardTypeEnum.Location }
                });
            }
        }
    }
}
