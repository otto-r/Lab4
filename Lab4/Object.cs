using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public abstract class Object : IPrintable
    {
        protected enum Objects { Wall = '#', Floor = '-', Player = '@', Door = 'D', Monster = 'M' };
        protected char Symbol;
        protected bool Solid;
        protected bool Danger;
        public static int Score;

        public Object()
        {
            Symbol = (char)Objects.Floor;
        }

        public char GetSymbol()
        {
            return Symbol;
        }

        public bool GetDanger()
        {
            return Danger;
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
