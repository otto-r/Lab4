using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Exit : Tile, IPrintable
    {
        public Exit()
        {
            Symbol = (char)Objects.Exit;
            Solid = false;
        }
        public override void PrintSymbol(bool isHurt)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(Symbol);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
