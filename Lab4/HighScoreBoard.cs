using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class HighScoreBoard
    {
        public static void PlayerHighScore()
        {
            Console.CursorVisible = true;
            string HighScore;   //Checks for HighScore.csv if no creates HighScore.csv
            if (File.Exists("HighScore.csv"))
            {

            }
            else
            {
                using (FileStream fs = File.Create("HighScore.csv")) ;
            }
            using (var streamReader = new StreamReader(@"HighScore.csv", Encoding.UTF8))    //sets up text file as source to read and write 
            {
                HighScore = streamReader.ReadToEnd();
            }

            List<HighScore> ScoreList = new List<HighScore>();

            //Count for ID
            int n = 1;
            foreach (var entry in HighScore)
            {
                if (entry == '\n') n++;
            }
            Console.Clear();


            while (true)
            {
                Console.Clear();
                Console.WriteLine("                 High scores");
                Console.Write("\n\n             Please enter name: ");  //Add player score to high score
                string name = Console.ReadLine();
                if (name.Contains(",") == false && name.Contains(" ") == false && String.IsNullOrEmpty(name) == false) //Makes some characters illegal
                {
                    if (name.Length > 25)   //Limits name length
                    {
                        string idNameAndScore = n + "," + name.Substring(0, 24) + "," + Player.Score + "\n";
                        HighScore += idNameAndScore;
                        using (StreamWriter file = new StreamWriter("HighScore.csv", true))
                        {
                            file.WriteLine(n + "," + name.Substring(0, 24) + "," + Player.Score);
                        }
                        break;
                    }
                    else
                    {
                        string nameAndScore = n + "," + name + "," + Player.Score + "\n";
                        HighScore += nameAndScore;
                        using (StreamWriter file = new StreamWriter("HighScore.csv", true))
                        {
                            file.WriteLine(n + "," + name + "," + Player.Score);
                        }
                        break;

                    }
                }
                else
                {
                    Console.WriteLine("\n\n             Illegal character used, blankspaces and commas are not allowed.");
                    Console.ReadLine();
                }
            }

            while (true)    //Loads scores from resource .csv
            {
                if (!String.IsNullOrEmpty(HighScore))
                {
                    //Add scores to list
                    int c = 0;
                    int index = 0;
                    foreach (var symbol in HighScore)   //Index of second comma
                    {
                        if (c == 2)
                        {
                            break;
                        }
                        index++;
                        if (symbol == ',')
                        {
                            c++;
                        }
                    }
                    string name = (HighScore.Substring(HighScore.IndexOf(",") + 1, index - (HighScore.IndexOf(",") + 2)));
                    int score = int.Parse(HighScore.Substring(index, (HighScore.IndexOf("\n") - index)));
                    int id = int.Parse(HighScore.Substring(0, HighScore.IndexOf(",")));

                    ScoreList.Add(new HighScore(name, score, id));


                    HighScore = HighScore.Substring(HighScore.IndexOf("\n") + 1);
                }
                else
                {
                    break;
                }

            }
            //Identify player
            var playerId = ScoreList.Count;
            Console.WriteLine(playerId);

            //Sorts scores form highest to lowest
            ScoreList.Sort(delegate (HighScore x, HighScore y)
            {
                return x.Score.CompareTo(y.Score);
            });

            //Prints high scoreboard to screen (top 10)
            Console.Clear();
            Console.WriteLine("         High Score Leaderboard:\n");
            int counter = 0;
            foreach (var higscore in ScoreList)
            {
                if (higscore.Name.Length > 8 && higscore.Id == playerId)    //No long names printed
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (counter == 9)
                    {
                        Console.WriteLine($"            {counter + 1}: {higscore.Name.Substring(0, 8)}...{higscore.Score}");

                    }
                    else
                    {
                        Console.WriteLine($"            {counter + 1}: {higscore.Name.Substring(0, 8)}... {higscore.Score}");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (higscore.Id == playerId)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"            {counter + 1}: {higscore.Name} ");
                    if (higscore.Name.Length < 11 && counter == 9)
                    {
                        for (int i = 0; i < 10 - higscore.Name.Length; i++)
                        {
                            Console.Write(" ");
                        }
                    }
                    else if (higscore.Name.Length < 11)
                    {
                        for (int i = 0; i < 11 - higscore.Name.Length; i++)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine($"{higscore.Score}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (higscore.Name.Length > 8)
                {
                    Console.WriteLine($"            {counter + 1}: {higscore.Name.Substring(0, 8)}... {higscore.Score}");  //No long names printed
                }
                else
                {
                    Console.Write($"            {counter + 1}: {higscore.Name} ");
                    if (higscore.Name.Length < 11 && counter == 9)
                    {
                        for (int i = 0; i < 10 - higscore.Name.Length; i++)
                        {
                            Console.Write(" ");
                        }
                    }
                    else if (higscore.Name.Length < 11)
                    {
                        for (int i = 0; i < 11 - higscore.Name.Length; i++)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine($"{higscore.Score}");
                }
                counter++;
                if (counter == 10)
                {
                    break;
                }
            }
                Console.WriteLine("\n\n\n");
        }
    }
}
