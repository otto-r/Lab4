using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public abstract class Object : IPrintable
    {
        protected char Symbol;
        protected bool Solid;

        public Object()
        {
            Symbol = '-';
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
