using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Key : Object , IPrintable
    {
        public Key()
        {
            Symbol = (char)Objects.Key;
            Solid = false;
        }
        public override void PrintSymbol(bool isHurt)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Symbol);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
