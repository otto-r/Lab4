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
            Monster monster1 = new Monster();
          
            Object[,] map = new Object[,] { { new Wall(), new Wall(), new Wall(), new Wall(), new Wall() },
                { new Wall(), new Floor(), new Floor(), new Floor(), new Wall() },
                { new Wall(), new Floor(), new Floor(), new Floor(), new Wall() },
                { new Wall(), new Floor(), new Floor(), new Floor(), new Wall() },
                { new Wall(), new Wall(), new Wall(), new Wall(), new Wall() }};
            
            map[2, 2] = player;
            map[3, 1] = monster1;

            char input;
            while (true)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        map[i, j].PrintSymbol();
                    }
                    Console.WriteLine();
                }
                input = Console.ReadKey(true).KeyChar;
                map = player.MovePlayer(input, map, player);
                map = monster1.MoveMonster(map, monster1);
                Console.Clear();
            }
        }
    }
}
