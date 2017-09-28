using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Jacket : Tile , IPrintable
    {
        public Jacket()
        {
            Symbol = (char)Objects.Jacket;
            Solid = false;
            Name = "Jacket";
        }
        public override void PrintSymbol(bool isHurt)
        {
            if (Visible)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(Symbol);
                Console.ForegroundColor = ConsoleColor.White;
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
