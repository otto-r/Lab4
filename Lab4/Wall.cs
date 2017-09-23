using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Wall : Object , IPrintable
    {
        public Wall()
        {
            Symbol = (char)Objects.Wall;
            Solid = true;
        }
        public override void PrintSymbol(bool isHurt)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Symbol);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
