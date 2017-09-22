using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Player : Object
    {
        public Player()
        {
            Symbol = '@';
        }

        public override void PrintSymbol()
        {
            Console.Write('@');
        }
    }
}
