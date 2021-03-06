﻿using System;
using Onirim.Model;
using System.Linq;

namespace Onirim.Command
{
    public class GainDoor : BaseCommand
    {
        private readonly CardColorEnum _color;

        public GainDoor(CardColorEnum color)
        {
            _color = color;
        }

        public override void Execute(GameModel gameState)
        {
            var door = gameState.MainDeck
                .Where(x => x.Type == CardTypeEnum.Door)
                .FirstOrDefault(x => x.Color == _color);
            if(door != null)
            {
                gameState.Doors.Add(door);
                gameState.MainDeck.Remove(door);
            }
            if(gameState.Doors.Count() == 8)
            {
                NextCommand = new Win();
            }
            else
            {
                NextCommand = new Shuffle(new Draw());
            }
        }
    }
}