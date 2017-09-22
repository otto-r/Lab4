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
            Symbol = 'D';
            Solid = false;
        }
        public override void PrintSymbol()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write('D');
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
