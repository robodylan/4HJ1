using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Import SFML
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
namespace _4HJ1
{
    class Player
    {
        public static int X, Y;
        public static Sprite sprite;
        public static int verticalSpeed;
        public static int horizontalSpeed;
        public static void Load()
        {
            /* Set Sprite*/
            sprite = new Sprite(new Texture(new Image("Content/Player.png")), new IntRect(0, 0, 64, 64));
            /* Set Starting Position */
            X = 100;
            Y = 100;
            /* Set Starting Speed */
        }

        public static void updatePosition()
        {
            X += horizontalSpeed;
            Y += verticalSpeed;
            if (Player.X > 800 - 64) X -= 1;
            if (Player.X < 0) X += 1;
            if (Player.Y > 600 - 64) Y -= 1;
            if (Player.Y < 0) Y += 1;
            sprite.Position = new Vector2f(X,Y);
        }
    }
}
