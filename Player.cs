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

        public static void Load()
        {
            /* Set Sprite */
            sprite = new Sprite(new Texture(new Image("Content/Player.png")), new IntRect(0, 0, 64, 64));
            /* Set Starting Position */
            X = 100;
            Y = 100;
        }

        public static void updatePosition()
        {
            sprite.Position = new Vector2f(X,Y);
        }
    }
}
