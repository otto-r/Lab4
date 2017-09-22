using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public abstract class Object : IPrintable
    {
        protected enum Objects { Wall = '#', Floor = '-', Player = '@', Door = 'D' };
        protected char Symbol;
        protected bool Solid;

        public Object()
        {
            Symbol = (char)Objects.Floor;
        }

        public char GetSymbol()
        {
            return Symbol;
        }

        public bool IsSolid()
        {
            return Solid;
        }
        public virtual void PrintSymbol()
        {
            Console.Write('-');
        }

    }
}
