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
            Console.Write(@"| _ | _____ |/////////////|+-+-+-+-+-+-+-|\\\\\\\\\\\\\|_____|_|
| ____ | __ |/////////////|-+-+______+-+-|\\\\\\\\\\\\\|__|____|
| _ | _____ |/////////////|+-+I      |+-+|\\\\\\\\\\\\\|_____|_|
| ____ | __ |/////////////|-+-| ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("EXIT ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"|-+-|\\\\\\\\\\\\\|__|____|
| _ | _____ |/////////////|+-+|      | ++|\\\\\\\\\\\\\|_____|_|
| ____ | __ |/////////////|-+-I      |-+-|\\\\\\\\\\\\\|__|____|
| _ | _____ |/////////////|+-+|     o|+-+|\\\\\\\\\\\\\|_____|_|
| ____ | __ |/////////////|-+-|      |-+-|\\\\\\\\\\\\\|__|____|
| _ | _____ |/////////////|+-+I      |+-+|\\\\\\\\\\\\\|_____|_|
| ____ | __ |/////////////|===--------===|\\\\\\\\\\\\\|__|____|
| _ | _____ |/////////////                \\\\\\\\\\\\\|_____|_|
| ____ | __ |////////////                  \\\\\\\\\\\\|__|____|
| _ | _____ |///////////                    \\\\\\\\\\\|_____|_|
| ____ | __ |//////////                      \\\\\\\\\\|__|____|
| _ | _____ |/////////                        \\\\\\\\\|_____|_|
| ____ | __ |////////                          \\\\\\\\|__|____|
| _ | _____ |///////                            \\\\\\\|_____|_|
| ____ | __ |//////                              \\\\\\|__|____|
| _ | _____ |/////         Congratulations!       \\\\\|_____|_|");
            Console.Write($"                    You reached the Exit in");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($" {Player.Score}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" moves.\n\n                     Please press ENTER to continue");
            Console.ReadLine();
            HighScoreBoard.PlayerHighScore();
        }
    }
}
