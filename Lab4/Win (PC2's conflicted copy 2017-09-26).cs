using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab4
{
    public class Win
    {
        public static void YouWin()
        {

            //string fileContent = Properties.Resources.HighScore;
            //using (var reader = new StringReader(fileContent))
            //{
            //    string line;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        //string[] split = line.Split('|');
            //        string name = split[0];
            //        string score = ;
            //    }
            //}
            //System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
            //file.WriteLine(score);

            Console.Clear();
            Console.WriteLine($"You reached the end in {Player.Score} turns.");
            Console.WriteLine(Properties.Resources.HighScore);
            Console.ReadLine();
        }
    }
}
