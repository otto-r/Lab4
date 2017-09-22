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
            Player player = new Player();
            Object temp = new Floor();
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

            char input;
            while (true)
            {
                input = Console.ReadKey(true).KeyChar;
                map = player.MovePlayer(input, map, temp, player);
                Console.Clear();
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(map[i, j].GetSymbol());
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
