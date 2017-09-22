using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Wall w1 = new Wall();
            Door d1 = new Door();
            Console.WriteLine(w1.GetSymbol());
            Console.WriteLine("door"+d1.GetSymbol());
        }
    }
}
