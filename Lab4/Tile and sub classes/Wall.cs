using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Wall : Tile , IPrintable
    {
        public Wall(bool visible)
        {
            Symbol = (char)Objects.Wall;
            Solid = true;
            Visible = visible;
        }
        public override void PrintSymbol(bool isHurt)
        {
            if (Visible)
            {
            Console.ForegroundColor = ConsoleColor.White;
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
