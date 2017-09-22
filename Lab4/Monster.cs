using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Monster : Object , IPrintable
    {
        private int XPosition;
        private int YPosition;
        Object temp = new Floor();
        Random r = new Random();

        public Monster()
        {
            XPosition = 3;
            YPosition = 1;
            Symbol = (char)Objects.Monster;
            Solid = true;
        }

        public override void PrintSymbol()
        {
            Console.Write(Symbol);
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

        public Object[,] MoveMonster(Object[,] map, Monster monster)
        {
            int direction = r.Next(0, 4);
            if (direction == 0)
            {
                if (!map[GetXPosition() - 1, GetYPosition()].IsSolid())
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition() - 1, GetYPosition()];
                    map[GetXPosition() - 1, GetYPosition()] = monster;
                    SetXPosition(GetXPosition() - 1);
                }
            }
            if (direction == 1)
            {
                if (!map[GetXPosition() + 1, GetYPosition()].IsSolid())
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition() + 1, GetYPosition()];
                    map[GetXPosition() + 1, GetYPosition()] = monster;
                    SetXPosition(GetXPosition() + 1);
                }
            }
            if (direction == 2)
            {
                if (!map[GetXPosition(), GetYPosition() - 1].IsSolid())
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition(), GetYPosition() - 1];
                    map[GetXPosition(), GetYPosition() - 1] = monster;
                    SetYPosition(GetYPosition() - 1);
                }
            }
            if (direction == 3)
            {
                if (!map[GetXPosition(), GetYPosition() + 1].IsSolid())
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition(), GetYPosition() + 1];
                    map[GetXPosition(), GetYPosition() + 1] = monster;
                    SetYPosition(GetYPosition() + 1);
                }
            }
            return map;
        }
    }
}
