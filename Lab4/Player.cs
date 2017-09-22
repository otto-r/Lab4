using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Player : Object, IPrintable
    {
        private int XPosition;
        private int YPosition;
        private bool Hurt;
        Object temp = new Floor();

        public Player()
        {
            XPosition = 2;
            YPosition = 2;
            Symbol = (char)Objects.Player;
            Solid = true;
        }

        public override void PrintSymbol(bool isHurt)
        {
            if (isHurt)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Symbol);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(Symbol);
            }
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

        public bool IsHurt()
        {
            return Hurt;
        }

        public void ClearHurt()
        {
            Hurt = false;
        }

        public Object[,] MovePlayer(char input, Object[,] map, Player player)
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
                if (map[GetXPosition() - 1, GetYPosition()].GetDanger())
                {
                    Player.Score += 4;
                    Hurt = true;
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
                if (map[GetXPosition() + 1, GetYPosition()].GetDanger())
                {
                    Player.Score += 4;
                    Hurt = true;
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
                if (map[GetXPosition(), GetYPosition() - 1].GetDanger())
                {
                    Player.Score += 4;
                    Hurt = true;
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
                if (map[GetXPosition(), GetYPosition() + 1].GetDanger())
                {
                    Player.Score += 4;
                    Hurt = true;
                }
            }
            return map;
        }
    }
}
