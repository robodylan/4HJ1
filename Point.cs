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
    class Point
    {
        public float X, Y;
        public static float Speed = 0.01f;
        public Point(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
        public void updatePosition()
        {
            X += Speed;
        }
    }
}
