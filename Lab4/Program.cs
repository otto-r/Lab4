using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Wall w1 = new Wall();
            Door d1 = new Door();
            Console.WriteLine(w1.GetSymbol());
            Console.WriteLine("door"+d1.GetSymbol());
            Object[] array = new Object[5];
        }
        public static void MovingPlayer()
        {
            // Moving
            Object PLayerPosY = ;
            ConsoleKeyInfo a;
            a = Console.ReadKey();
            if (a.Key == ConsoleKey.A)
            {
                if (PlayerPosY-1 !=Object. )
                {
                    PlayerPosY--;
                }
            }
            else if (a.Key == ConsoleKey.D)
            {
                if (y < columns - 2)
                {
                    y++;
                }
            }
            else if (a.Key == ConsoleKey.S)
            {
                if (x < rows - 2)
                {
                    x++;
                }
            }
            else if (a.Key == ConsoleKey.W)
            {
                if (x != 1)
                {
                    x--;
                }
            }
            else if (a.Key == ConsoleKey.Q)
            {
                break;
            }
            Console.Clear();

        }
    }
}
