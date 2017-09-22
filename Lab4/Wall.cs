using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Wall : Object
    {
        public Wall()
        {
            Symbol = '#';
            Solid = true;
        }
        public override void PrintSymbol()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write('#');
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
