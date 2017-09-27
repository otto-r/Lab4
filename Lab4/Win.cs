using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Win
    {
        public static void YouWin()
        {
            Console.Clear();
            Console.WriteLine($"You reached the end in {Player.Score} turns.");
            Console.ReadLine();
            HighScoreBoard.PlayerHighScore();
        }
    }
}
