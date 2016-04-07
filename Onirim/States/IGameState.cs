using Microsoft.Xna.Framework.Graphics;
using Onirim.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.States
{
    public interface IGameState
    {
        void OnExit();
        void OnEnter();
        void Update(InputState inputState);
        void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight);
    }
}
