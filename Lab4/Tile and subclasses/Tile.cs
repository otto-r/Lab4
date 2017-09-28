using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public abstract class Tile : IPrintable
    {
        protected enum Objects { Wall = '#', Floor = '-', Player = '@', Door = 'D', Monster = 'M', Key = 'k', SuperKey = 'K', Void = 'X', Exit = 'O', Mud = '~', Lever = '|', Boots = 'b', Fire = '^', Jacket = 'j' };
        protected char Symbol;
        protected bool Solid;
        protected bool Danger;
        protected bool Visible;
        protected bool Pulled;
        protected bool Extinguished;
        protected String Name;
        public static int Score;

        public Tile()
        {
            Symbol = (char)Objects.Floor;
            Visible = false;
            Name = "None";
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

        public void SetSolid(bool b)
        {
            Solid = b;
        }

        public bool IsVisible()
        {
            return Visible;
        }

        public void MakeVisible()
        {
            Visible = true;
        }

        public void PullLever()
        {
            Pulled = true;
        }

        public bool IsPulled()
        {
            return Pulled;
        }

        public String GetName()
        {
            return Name;
        }

        public void Extinguish()
        {
            Extinguished = true;
        }

        public bool GetExtinguished()
        {
            return Extinguished;
        }

        public virtual void PrintSymbol(bool isHurt)
        {
            Console.Write('-');
        }

    }
}
