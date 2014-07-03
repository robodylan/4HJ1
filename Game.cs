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
    class Game
    {
        //Declare Variables and Assets
        public static RenderWindow window;
        public static int MouseX;
        public static int MouseY;
        public int W, H;
        public Game(uint W, uint H, string Title)
        {
            window = new RenderWindow(new VideoMode(W,H), Title);
            this.W = (int)W;
            this.H = (int)H;
        }

        public void Start()
        {
            //Load Assets and Set Variables
            window.MouseMoved += MouseInput;
            window.KeyPressed += KeyboardInput;
            Player.Load();
            while(window.IsOpen())
            {
                window.DispatchEvents();
                window.Clear(new Color(0,0,0));
                Draw();
                window.Display();
            }
        }

        public void Draw()
        {
            Player.updatePosition();
            window.Draw(Player.sprite);
        }
        public void MouseInput(Object sender, MouseMoveEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
        }
        public void KeyboardInput(Object sender, KeyEventArgs e)
        {
            switch(e.Code)
            {
                case Keyboard.Key.W: if(Player.Y > 0) Player.Y -= 10;  break;
                case Keyboard.Key.S: if(Player.Y < H - 64) Player.Y += 10; break;
            }
        }
    }
}
