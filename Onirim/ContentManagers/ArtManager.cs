using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Onirim.ContentManagers
{
    public static class ArtManager
    {
        public static void InitializeGraphcis(ContentManager content)
        {
            RedSun = content.Load<Texture2D>("RedSun");
            RedMoon = content.Load<Texture2D>("RedMoon");
            RedKey = content.Load<Texture2D>("RedKey");
            RedDoor = content.Load<Texture2D>("RedDoor");

            BlueSun = content.Load<Texture2D>("BlueSun");
            BlueMoon = content.Load<Texture2D>("BlueMoon");
            BlueKey = content.Load<Texture2D>("BlueKey");
            BlueDoor = content.Load<Texture2D>("BlueDoor");

            GreenSun = content.Load<Texture2D>("GreenSun");
            GreenMoon = content.Load<Texture2D>("GreenMoon");
            GreenKey = content.Load<Texture2D>("GreenKey");
            GreenDoor = content.Load<Texture2D>("GreenDoor");

            BrownSun = content.Load<Texture2D>("BrownSun");
            BrownMoon = content.Load<Texture2D>("BrownMoon");
            BrownKey = content.Load<Texture2D>("BrownKey");
            BrownDoor = content.Load<Texture2D>("BrownDoor");

            Nightmare = content.Load<Texture2D>("Nightmare");

            DefaultBack = content.Load<Texture2D>("DefaultBack");
        }

        public static Texture2D RedSun { get; set; }
        public static Texture2D RedMoon { get; set; }
        public static Texture2D RedKey { get; set; }
        public static Texture2D RedDoor { get; set; }

        public static Texture2D BlueSun { get; set; }
        public static Texture2D BlueMoon { get; set; }
        public static Texture2D BlueKey { get; set; }
        public static Texture2D BlueDoor { get; set; }

        public static Texture2D GreenSun { get; set; }
        public static Texture2D GreenMoon { get; set; }
        public static Texture2D GreenKey { get; set; }
        public static Texture2D GreenDoor { get; set; }

        public static Texture2D BrownSun { get; set; }
        public static Texture2D BrownMoon { get; set; }
        public static Texture2D BrownKey { get; set; }
        public static Texture2D BrownDoor { get; set; }

        public static Texture2D Nightmare { get; set; }

        public static Texture2D DefaultBack { get; set; }
    }
}
