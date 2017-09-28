﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Fire : Tile, IPrintable
    {
        public Fire()
        {
            Symbol = (char)Objects.Fire;
            Solid = false;
        }

        public override void PrintSymbol(bool isHurt)
        {
            if (Visible)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Symbol);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(Symbol);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
