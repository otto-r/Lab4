using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Door : Tile, IPrintable
    {
        public Door()
        {
            Symbol = (char)Objects.Door;
            Solid = true;
        }
        public override void PrintSymbol(bool isHurt)
        {
            if (Visible)
            {
                if (Solid)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(Symbol);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
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
