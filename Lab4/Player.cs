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
        private bool NeedKey;
        private bool UsedKey;
        private bool GotKey;
        private bool PlayerWin;
        private int Keys;
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
            if (isHurt) //Player is hurt, make it red
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

        public void ClearConditions() //Clear all temporary conditions
        {
            Hurt = false;
            NeedKey = false;
            UsedKey = false;
            GotKey = false;
        }

        public int GetKeys()
        {
            return Keys;
        }

        public bool GetHurt()
        {
            return Hurt;
        }

        public bool GetNeedKey()
        {
            return NeedKey;
        }

        public bool GetUsedKey()
        {
            return UsedKey;
        }

        public bool GetGotKey()
        {
            return GotKey;
        }

        public bool GetPlayerWin()
        {
            return PlayerWin;
        }

        public Object[,] MovePlayer(char input, Object[,] map, Player player)
        {
            if (input == 'w') //Go north
            {
                if (map[GetXPosition() - 1, GetYPosition()].GetDanger()) //Checks if object is dangerous
                {
                    Player.Score += 4;
                    Hurt = true;
                }
                if (map[GetXPosition() - 1, GetYPosition()].IsSolid() && map[GetXPosition() - 1, GetYPosition()] is Door) //Checks for locked door
                {
                    if (Keys > 0) //Unlock door
                    {
                        UsedKey = true;
                        Keys--;
                        map[GetXPosition() - 1, GetYPosition()].SetSolid(false);
                    }
                    else //Player needs a key
                    {
                        NeedKey = true;
                    }
                }
                if (!map[GetXPosition() - 1, GetYPosition()].IsSolid()) //Checks if object is solid
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition() - 1, GetYPosition()];
                    if (temp is Key) //Checks if object is key
                    {
                        GotKey = true;
                        temp = new Floor();
                        Keys++;
                    }
                    if (temp is Exit) //Checks if object is Exit
                    {
                        PlayerWin = true;
                    }
                    map[GetXPosition() - 1, GetYPosition()] = player;
                    SetXPosition(GetXPosition() - 1);
                }
            }
            if (input == 's') //Go south
            {
                if (map[GetXPosition() + 1, GetYPosition()].GetDanger()) //Checks if object is dangerous
                {
                    Player.Score += 4;
                    Hurt = true;
                }
                if (map[GetXPosition() + 1, GetYPosition()].IsSolid() && map[GetXPosition() + 1, GetYPosition()] is Door) //Checks for locked door
                {
                    if (Keys > 0) //Unlock door
                    {
                        UsedKey = true;
                        Keys--;
                        map[GetXPosition() + 1, GetYPosition()].SetSolid(false);
                    }
                    else //Player needs a key
                    {
                        NeedKey = true;
                    }
                }
                if (!map[GetXPosition() + 1, GetYPosition()].IsSolid()) //Checks if object is solid
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition() + 1, GetYPosition()];
                    if (temp is Key) //Checks if object is key
                    {
                        GotKey = true;
                        temp = new Floor();
                        Keys++;
                    }
                    if (temp is Exit) //Checks if object is Exit
                    {
                        PlayerWin = true;
                    }
                    map[GetXPosition() + 1, GetYPosition()] = player;
                    SetXPosition(GetXPosition() + 1);
                }
            }
            if (input == 'a') //Go west
            {
                if (map[GetXPosition(), GetYPosition() - 1].GetDanger()) //Checks if object is dangerous
                {
                    Player.Score += 4;
                    Hurt = true;
                }
                if (map[GetXPosition(), GetYPosition() - 1].IsSolid() && map[GetXPosition(), GetYPosition() - 1] is Door) //Checks for locked door
                {
                    if (Keys > 0) //Unlock door
                    {
                        UsedKey = true;
                        Keys--;
                        map[GetXPosition(), GetYPosition() - 1].SetSolid(false);
                    }
                    else //Player needs a key
                    {
                        NeedKey = true;
                    }
                }
                if (!map[GetXPosition(), GetYPosition() - 1].IsSolid()) //Checks if object is solid
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition(), GetYPosition() - 1];
                    if (temp is Key) //Checks if object is key
                    {
                        GotKey = true;
                        temp = new Floor();
                        Keys++;
                    }
                    if (temp is Exit) //Checks if object is Exit
                    {
                        PlayerWin = true;
                    }
                    map[GetXPosition(), GetYPosition() - 1] = player;
                    SetYPosition(GetYPosition() - 1);
                }
            }
            if (input == 'd') //Go east
            {
                if (map[GetXPosition(), GetYPosition() + 1].GetDanger()) //Checks if object is dangerous
                {
                    Player.Score += 4;
                    Hurt = true;
                }
                if (map[GetXPosition(), GetYPosition() + 1].IsSolid() && map[GetXPosition(), GetYPosition() + 1] is Door) //Checks for locked door
                {
                    if (Keys > 0) //Unlock door
                    {
                        UsedKey = true;
                        Keys--;
                        map[GetXPosition(), GetYPosition() + 1].SetSolid(false);
                    }
                    else //Player needs a key
                    {
                        NeedKey = true;
                    }
                }
                if (!map[GetXPosition(), GetYPosition() + 1].IsSolid()) //Checks if object is solid
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition(), GetYPosition() + 1];
                    if (temp is Key) //Checks if object is key
                    {
                        GotKey = true;
                        temp = new Floor();
                        Keys++;
                    }
                    if (temp is Exit) //Checks if object is Exit
                    {
                        PlayerWin = true;
                    }
                    map[GetXPosition(), GetYPosition() + 1] = player;
                    SetYPosition(GetYPosition() + 1);
                }
            }
            return map;
        }
    }
}
