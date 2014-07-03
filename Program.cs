using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4HJ1
{
    class Program
    {
        public static Game g;
        static void Main(string[] args)
        {
            Game g = new Game(800, 600, "4 Hour Jam #1");
            g.Start();
        }
    }
}
