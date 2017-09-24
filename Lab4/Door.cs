using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Door : Object , IPrintable
    {
        public Door()
        {
            Symbol = (char)Objects.Door;
            Solid = true;
        }
        public override void PrintSymbol(bool isHurt)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(Symbol);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
