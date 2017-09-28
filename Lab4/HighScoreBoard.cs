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

            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.Write("     Please enter name: ");
                string name = Console.ReadLine();
                if (name.Contains(",") == false && name.Contains(" ") == false && String.IsNullOrEmpty(name) == false) //Makes some characters illegal
                {
                    if (name.Length > 25)   //Limits name length
                    {
                        string nameAndScore = name.Substring(0, 24) + "," + Player.Score + "\n";
                        HighScore += nameAndScore;
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter("HighScore.csv", true))
                        {
                            file.WriteLine(name.Substring(0, 24) + "," + Player.Score);
                        }
                        break;
                    }
                    else
                    {
                        string nameAndScore = name + "," + Player.Score + "\n";
                        HighScore += nameAndScore;
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter("HighScore.csv", true))
                        {
                            file.WriteLine(name + "," + Player.Score);
                        }
                        break;

                    }
                }
                else
                {

                }
            }

            while (true)    //Loads scores from resource .txt
            {
                if (HighScore.IndexOf(",") == 0)
                {
                    Console.WriteLine("first line");
                    HighScore = HighScore.Substring(1);
                }
                else if (!String.IsNullOrEmpty(HighScore))
                {
                    ScoreList.Add(new HighScore(HighScore.Substring(0, HighScore.IndexOf(",")), int.Parse(HighScore.Substring(HighScore.IndexOf(",") + 1, (HighScore.IndexOf("\n")) - HighScore.IndexOf(",") - 1))));


                    HighScore = HighScore.Substring(HighScore.IndexOf("\n") + 1);
                }
                else
                {
                    break;
                }

            }
            //Sorts scores form highest to lowest
            ScoreList.Sort(delegate (HighScore x, HighScore y)
            {
                return x.Score.CompareTo(y.Score);
            });

            //Prints highscore to screen
            Console.WriteLine("     High Score:");
            foreach (var higscore in ScoreList)
            {
                if (higscore.Name.Length > 8)
                {
                    Console.WriteLine($"{higscore.Name.Substring(0, 8)}...: {higscore.Score}");  //No long names printed
                }
                else
                {
                    Console.WriteLine($"{higscore.Name}: {higscore.Score}");
                }
            }

        }
    }
}
