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
            Monster monster1 = new Monster(4, 35);
            Monster monster2 = new Monster(15, 18);
            Monster monster3 = new Monster(15, 30);

            Tile[,] map = Map.GenerateMap(); //Create the map

            map[player.GetXPosition(), player.GetYPosition()] = player; //Place player
            map[monster1.GetXPosition(), monster1.GetYPosition()] = monster1; //Place monster1
            map[monster2.GetXPosition(), monster2.GetYPosition()] = monster2; //Place monster2
            map[monster3.GetXPosition(), monster3.GetYPosition()] = monster3; //Place monster3

            Random r = new Random();

            char input;

            map = player.ExpandVision(map, player); //Initial visibility

            Console.CursorVisible = false;

            while (true) //Main game loop
            {
                if (player.GetPulledLever()) //Turn off all fire if lever is pulled
                {
                    map = Fire.SetExtinguish(map);
                }
                for (int i = 0; i < Map.GetRows(); i++) //Print the map
                {
                    for (int j = 0; j < Map.GetColumns(); j++)
                    {
                        map[i, j].PrintSymbol(player.GetHurt());
                    }
                    if (i == Map.GetRows() / 3 - 2)
                    {
                        Console.WriteLine("     Legend");
                    }
                    else if (i == Map.GetRows() / 3 - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("     O");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Exit");
                    }
                    else if (i == Map.GetRows() / 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("     -");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Floor");
                    }
                    else if (i == Map.GetRows() / 3 + 1)
                    {
                        Console.WriteLine($"     #     Wall");
                    }
                    else if (i == Map.GetRows() / 3 + 2)
                    {
                        Console.WriteLine($"     D     Door");
                    }
                    else if (i == Map.GetRows() / 3 + 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("     k");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Key");
                    }
                    else if (i == Map.GetRows() / 3 + 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("     K");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Super Key");
                    }
                    else if (i == Map.GetRows() / 3 + 5)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("     |");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Lever");
                    }
                    else if (i == Map.GetRows() / 3 + 6)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("     ~");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Mud");
                    }
                    else if (i == Map.GetRows() / 3 + 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("     ^");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Fire");
                    }
                    else if (i == Map.GetRows() / 3 + 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("     M");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Monster");
                    }
                    else if (i == Map.GetRows() / 3 + 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("     b");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Boots");
                    }
                    else if (i == Map.GetRows() / 3 + 10)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("     j");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     Jacket");
                    }

                    else
                    {
                        Console.WriteLine();
                    }
                }


                if (player.GetHurt()) //The player was hurt
                {
                    Player.Score += 4;
                    Console.WriteLine("The monster hurt you! You lost 5 moves.                                                              ");
                }

                else if (player.GetNeedKey()) //The player needs a key
                {
                    Console.WriteLine("You need a key to open this door!                                                                        ");
                }

                else if (player.GetUsedKey()) //The player used a key
                {
                    Console.WriteLine("You used a key to open the door!                                                                 ");
                }

                else if (player.GetGotKey()) //The player got a key
                {
                    Console.WriteLine("You picked up a key!                                                                             ");
                }

                else if (player.GetGotSuperKey()) //The player got a key
                {
                    Console.WriteLine("You picked up a Superkey!                                                                    ");
                }

                else if (player.GetSteppedInMud()) //The player stepped in mud
                {
                    if (!(player.GetGear() is Boots))
                    {
                        Player.Score += 2;
                        Console.WriteLine("You stepped in mud! You lost 3 moves.                                                    ");
                    }
                    else
                    {
                        Console.WriteLine("Your boots makes it easy to walk in mud!                                                    ");
                    }
                }

                else if (player.GetSteppedInFire()) //The player stepped in fire
                {
                    if (!(player.GetGear() is Jacket))
                    {
                        Player.Score += 24;
                        Console.WriteLine("You stepped in fire! You lost 25 moves.                                                      ");
                    }
                    else
                    {
                        Console.WriteLine("Your fireproof jacket keeps you cool while walking through fire!                           ");
                    }
                }

                else if (player.GetPulledLever()) //The player pulled a lever
                {
                    Console.WriteLine("You pulled the lever!");
                }

                else if (player.GetGotBoots())
                {
                    Console.WriteLine("You picked up boots!                                                                       ");
                }

                else if (player.GetGotJacket())
                {
                    Console.WriteLine("You picked up a jacket!                                                                      ");
                }

                else
                {
                    Console.WriteLine("                                                                                                    ");
                }

                Console.WriteLine($"Keys: {player.GetKeys()} Super Keys: {Math.Ceiling(player.GetSuperKeys() / 3)} Moves: {Player.Score} Gear: {player.GetGear().GetName()}"); //Player stats
                //Console.WriteLine($"Gear: {player.GetGearName()}");

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
                map = monster3.MoveMonster(map, monster3, r.Next(0, 4)); //Move monster3

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
