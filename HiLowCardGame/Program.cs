using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLowCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager Game = new Manager();
            Game.Initial();
            Game.StartGame();
            Game.EndGame();
        }
    }
}
