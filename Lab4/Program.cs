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
            Monster monster1 = new Monster(3, 1);
            Monster monster2 = new Monster(3, 2);

            Object[,] map = Map.GenerateMap(); //Create the map

            map[player.GetXPosition(), player.GetYPosition()] = player; //Place player
            map[monster1.GetXPosition(), monster1.GetYPosition()] = monster1; //Place monster1
            map[monster2.GetXPosition(), monster2.GetYPosition()] = monster2; //Place monster2

            Random r = new Random();

            char input;

            while (true) //Main game loop
            {
                for (int i = 0; i < Map.GetRows(); i++) //Print the map
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

                Console.WriteLine($"Keys: {player.GetKeys()} Moves: {Player.Score}"); //Player stats

                if (player.GetHurt()) //The player was hurt
                {
                    Console.WriteLine("The monster hurt you! You lost 5 moves.");
                }

                if (player.GetNeedKey()) //The player needs a key
                {
                    Console.WriteLine("You need a key to open this door!");
                }

                if (player.GetUsedKey()) //The player used a key
                {
                    Console.WriteLine("You used a key to open the door!");
                }

                if (player.GetGotKey()) //The player got a key
                {
                    Console.WriteLine("You picked up a key!");
                }

                player.ClearConditions(); //Clear special conditions

                while (true) //Waits for legit input
                {
                    input = Console.ReadKey(true).KeyChar; //Get input
                    if (input == 'w' || input == 'a' || input == 's' || input == 'd')
                    {
                        break;
                    }
                }

                map = player.MovePlayer(input, map, player); //Move player
                map = monster1.MoveMonster(map, monster1, r.Next(0, 4)); //Move monster1
                map = monster2.MoveMonster(map, monster2, r.Next(0, 4)); //Move monster2

                Player.Score++; //Add a move

                if (player.GetPlayerWin()) //Player wins and ends game
                {
                    break;
                }
                Console.Clear();
            }
            Win.YouWin();
        }
    }
}
