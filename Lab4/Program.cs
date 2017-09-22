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
            Monster monster1 = new Monster();
          
            Object[,] map = new Object[6,22];
            StreamReader MapReader = new StreamReader("Map.txt");

            String MapString = MapReader.ReadToEnd();
            String MapString2 = MapString.Replace(Environment.NewLine, "");

            int counter = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 22; j++)
                {
                    if (MapString2[counter] == '#')
                    {
                        map[i, j] = new Wall();
                    }
                    else if (MapString2[counter] == 'D')
                    {
                        map[i, j] = new Door();
                    }
                    else if (MapString2[counter] == '-')

                    {
                        map[i, j] = new Floor();
                    }
                    //else if (MapString2[counter] == '')
                    //{
                    //    map[i, j] = new Floor();
                    //}
                    counter++;
                }
            }

            map[2, 2] = player;
            map[3, 1] = monster1;

            char input;
            while (true)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 22; j++)
                    {
                         map[i, j].PrintSymbol(player.IsHurt());
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine($"Moves: {Player.Score}");
                if (player.IsHurt())
                {
                    Console.WriteLine("The monster hurt you! You lost 5 moves.");
                }
                player.ClearHurt();
                input = Console.ReadKey(true).KeyChar;
                map = player.MovePlayer(input, map, player);
                map = monster1.MoveMonster(map, monster1);
                Player.Score++;
                Console.Clear();
            }
        }
    }
}
