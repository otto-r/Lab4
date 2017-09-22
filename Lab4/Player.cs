﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Player : Object , IPrintable
    {
        private int XPosition;
        private int YPosition;
        public Player()
        {
            XPosition = 2;
            YPosition = 2;
            Symbol = '@';
        }


        public override void PrintSymbol()
        {
            Console.Write('@');
        }
            
        public int GetXPosition()
        {
            return XPosition;
        }

        public int GetYPosition()
        {
            return YPosition;
        }

        public void SetXPosition(int x)
        {
            XPosition = x;
        }

        public void SetYPosition(int y)
        {
            YPosition = y;
        }

        public Object[,] MovePlayer(char input, Object[,] map, Object temp, Player player)
        {
            if (input == 'w')
            {
                if (!map[GetXPosition() - 1, GetYPosition()].IsSolid())
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition() - 1, GetYPosition()];
                    map[GetXPosition() - 1, GetYPosition()] = player;
                    SetXPosition(GetXPosition() - 1);
                }
            }
            if (input == 's')
            {
                if (!map[GetXPosition() + 1, GetYPosition()].IsSolid())
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition() + 1, GetYPosition()];
                    map[GetXPosition() + 1, GetYPosition()] = player;
                    SetXPosition(GetXPosition() + 1);
                }
            }
            if (input == 'a')
            {
                if (!map[GetXPosition(), GetYPosition() - 1].IsSolid())
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition(), GetYPosition() - 1];
                    map[GetXPosition(), GetYPosition() - 1] = player;
                    SetYPosition(GetYPosition() - 1);
                }
            }
            if (input == 'd')
            {
                if (!map[GetXPosition(), GetYPosition() + 1].IsSolid())
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition(), GetYPosition() + 1];
                    map[GetXPosition(), GetYPosition() + 1] = player;
                    SetYPosition(GetYPosition() + 1);
                }
            }
            return map;
        }
    }
}
