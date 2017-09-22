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
            Symbol = '-';
            Solid = false;
        }
        public override void PrintSymbol()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('-');
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
