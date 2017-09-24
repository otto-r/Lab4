using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            //Monster monster1 = new Monster();
            //Monster monster2 = new Monster();

            Object[,] map  = Map.GenerateMap();

            map[2, 2] = player;
            //map[3, 1] = monster1;
            //map[9, 33] = monster2;

            char input;
            while (true)
            {
                for (int i = 0; i < Map.GetRows(); i++)
                {
                    for (int j = 0; j < Map.GetColumns(); j++)
                    {
                        map[i, j].PrintSymbol(player.GetHurt());
                    }
                    if (i == Map.GetRows() / 2 - 1)
                    {
                        Console.WriteLine("     We could have some stats/info here maybe?");
                    }
                    else if (i == Map.GetRows() / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("     k");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Key, needed to open some doors.");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }

                Console.WriteLine($"Keys: {player.GetKeys()} Moves: {Player.Score}");

                if (player.GetHurt())
                {
                    Console.WriteLine("The monster hurt you! You lost 5 moves.");
                }
                
                if (player.GetNeedKey())
                {
                    Console.WriteLine("You need a key to open this door!");
                }

                if (player.GetUsedKey())
                {
                    Console.WriteLine("You used a key to open the door!");
                }

                if (player.GetGotKey())
                {
                    Console.WriteLine("You picked up a key!");
                }

                player.ClearConditions();

                // borde lägga till så att enbart WASD skickas in i metod, så att de inte räknas i "score". kan lägga meny etc på fler knappar
                input = Console.ReadKey(true).KeyChar;
                
                map = player.MovePlayer(input, map, player);
                //map = monster1.MoveMonster(map, monster1);
                //map = monster2.MoveMonster(map, monster2);

                Player.Score++;
                Console.Clear();
            }
        }
    }
}
