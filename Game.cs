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
        public static List<Point> points = new List<Point>();
        public int W, H;
        public static Sprite pointSprite;
        public static int Score;
        public static Sprite BG;
        public static Font F;
        public static int spawnTimeout = 60;
        public static Music m;
        public static bool lose;
        public Game(uint W, uint H, string Title)
        {
            window = new RenderWindow(new VideoMode(W,H), Title);
            this.W = (int)W;
            this.H = (int)H;
        }

        public void Start()
        {
            //Load Assets and Set Variables
            lose = false;
            m = new Music("Content/mixdown.ogg");
            m.Loop = true;
            m.Play();
            F = new Font("Content/Animated.ttf");
            BG = new Sprite(new Texture(new Image("Content/BG.png")), new IntRect(0, 0, W, H));
            pointSprite = new Sprite(new Texture(new Image("Content/Point.png")), new IntRect(0,0,16,16));
            window.MouseMoved += MouseInput;
            window.KeyPressed += KeyboardInput;
            window.KeyReleased += KeyboardReleaseInput;
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
            if(lose == true)
            {
                Score = 0;
                Point.Speed = .01f;
            }
            Point.Speed += 0.0001f;
            //Spawn Random Runner
            if (spawnTimeout > 1)
            {
                spawnTimeout--;
            }
            else
            {
                spawnTimeout = 100;
                points.Add(new Point(0, new Random(DateTime.Now.Millisecond).Next(0, 600)));
            }
            window.Draw(BG);
            for (int l = points.Count - 2; l >= 0; l--)
            {

                Point C = points[l];
                if (C.X + 14 > Player.X && C.X < Player.X + 64 && C.Y + 14 > Player.Y && C.Y < Player.Y + 64)
                {
                    points.Remove(points[l]);
                    Score = Score + 1;
                }
                if(C.X > W)
                {
                    points.Remove(points[l]);
                }
                if(C.X > 725)
                {
                    lose = true;
                }
                points[l].updatePosition();
                pointSprite.Position = new Vector2f((int)points[l].X,(int)points[l].Y);
                window.Draw(pointSprite);
            }
            Player.updatePosition();
            window.Draw(Player.sprite);
            window.Draw(new Text("Score: " + Score, F));
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
                case Keyboard.Key.W: Player.verticalSpeed = -1; break;
                case Keyboard.Key.S: Player.verticalSpeed = +1; break;
                case Keyboard.Key.A: Player.horizontalSpeed = -1;  break;
                case Keyboard.Key.D: Player.horizontalSpeed = +1; break;
            }
        }
        public void KeyboardReleaseInput(Object sender, KeyEventArgs e)
        {
            switch(e.Code)
            {
                case Keyboard.Key.W: Player.verticalSpeed = 0; break;
                case Keyboard.Key.S: Player.verticalSpeed = 0; break;
                case Keyboard.Key.A: Player.horizontalSpeed = 0;  break;
                case Keyboard.Key.D: Player.horizontalSpeed = 0; break;
            }
        }
    }
}
