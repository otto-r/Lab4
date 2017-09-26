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

            Tile[,] map = Map.GenerateMap(); //Create the map

            map[player.GetXPosition(), player.GetYPosition()] = player; //Place player
            map[monster1.GetXPosition(), monster1.GetYPosition()] = monster1; //Place monster1
            map[monster2.GetXPosition(), monster2.GetYPosition()] = monster2; //Place monster2

            Random r = new Random();

            char input;

            map = player.ExpandVision(map, player); //Initial visibility

            Console.CursorVisible = false;

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
                        Console.WriteLine("     Legend");
                    }
                    else if (i == Map.GetRows() / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("     -");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Floor");
                    }
                    else if (i == Map.GetRows() / 2 + 1)
                    {
                        Console.WriteLine($"     #     Wall");
                    }
                    else if (i == Map.GetRows() / 2 + 2)
                    {
                        Console.WriteLine($"     D     Door");
                    }
                    else if (i == Map.GetRows() / 2 + 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("     k");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Key");
                    }
                    else if (i == Map.GetRows() / 2 + 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("     K");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Super Key");
                    }
                    else if (i == Map.GetRows() / 2 + 5)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("     ~");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Mud");
                    }
                    else if (i == Map.GetRows() / 2 + 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("     M");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Monster");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }


                if (player.GetHurt()) //The player was hurt
                {
                    Player.Score += 4;
                    Console.WriteLine("The monster hurt you! You lost 5 moves.");
                }

                else if (player.GetNeedKey()) //The player needs a key
                {
                    Console.WriteLine("You need a key to open this door!");
                }

                else if (player.GetUsedKey()) //The player used a key
                {
                    Console.WriteLine("You used a key to open the door!");
                }

                else if (player.GetGotKey()) //The player got a key
                {
                    Console.WriteLine("You picked up a key!");
                }

                else if (player.GetGotSuperKey()) //The player got a key
                {
                    Console.WriteLine("You picked up a Superkey!");
                }

                else if (player.GetSteppedInMud())
                {
                    Player.Score += 2;
                    Console.WriteLine("You stepped in mud! You lost 3 moves.");
                }

                else if (player.GetPulledLever())
                {
                    Console.WriteLine("You pulled the lever!");
                }

                else
                {
                    Console.WriteLine("                                        ");
                }

                Console.WriteLine($"Keys: {player.GetKeys()} Super Keys: {player.GetSuperKeys()} Moves: {Player.Score}"); //Player stats

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
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
            }
            Win.YouWin();
        }
    }
}
