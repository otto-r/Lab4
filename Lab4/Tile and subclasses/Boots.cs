using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Boots : Tile , IPrintable
    {
        public Boots()
        {
            Symbol = (char)Objects.Boots;
            Solid = false;
            Name = "Boots";
        }
        public override void PrintSymbol(bool isHurt)
        {
            if (Visible)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
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
