using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Lever : Tile, IPrintable
    {
        public Lever()
        {
            Symbol = (char)Objects.Lever;
            Pulled = false;
        }

        public override void PrintSymbol(bool isHurt)
        {
            if (Visible)
            {
                if (Pulled)
                {
                    Symbol = '/';
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(Symbol);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(Symbol);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
