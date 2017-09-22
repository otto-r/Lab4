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

            Object[,] map = new Object[,] { { new Wall(), new Wall(), new Wall(), new Wall(), new Wall() },
                { new Wall(), new Floor(), new Floor(), new Floor(), new Wall() },
                { new Wall(), new Floor(), new Player(), new Floor(), new Wall() },
                { new Wall(), new Floor(), new Floor(), new Floor(), new Wall() },
                { new Wall(), new Wall(), new Wall(), new Wall(), new Wall() }};
            
            for(int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(map[i, j].GetSymbol());
                }
                Console.WriteLine();
            }
            
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
