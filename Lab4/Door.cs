﻿using System;
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
            Symbol = (char)Objects.Door;
            Solid = false;
        }
        public override void PrintSymbol()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(Symbol);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
