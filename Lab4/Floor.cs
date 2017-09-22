using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Floor : Object , IPrintable
    {
        public Floor()
        {
            Symbol = (char)Objects.Floor;
            Solid = false;
        }
        public override void PrintSymbol(bool isHurt)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Symbol);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
