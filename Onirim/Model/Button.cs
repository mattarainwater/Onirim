using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Onirim.Command;
using Microsoft.Xna.Framework;

namespace Onirim.Model
{
    public class Button
    {
        public BaseCommand Command { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle HitBox { get; set; }

        public bool BeenClicked(MouseState mouseState)
        {
            return HitBox.Contains(mouseState.Position);
        }
    }
}
