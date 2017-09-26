using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Player : Tile, IPrintable
    {
        private int XPosition;
        private int YPosition;
        private bool Hurt;
        private bool NeedKey;
        private bool UsedKey;
        private bool GotKey;
        private bool GotSuperKey;
        private bool PlayerWin;
        private bool SteppedInMud;
        private int Keys;
        private int SuperKeys;
        Tile temp = new Floor(true);

        public Player()
        {
            XPosition = 2;
            YPosition = 2;
            Symbol = (char)Objects.Player;
            Solid = true;
            Visible = true;
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
            GotSuperKey = false;
            SteppedInMud = false;
        }

        public int GetKeys()
        {
            return Keys;
        }

        public int GetSuperKeys()
        {
            return SuperKeys;
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

        public bool GetGotSuperKey()
        {
            return GotSuperKey;
        }

        public bool GetPlayerWin()
        {
            return PlayerWin;
        }

        public bool GetSteppedInMud()
        {
            return SteppedInMud;
        }

        public Tile[,] MovePlayer(char input, Tile[,] map, Player player)
        {
            if (input == 'w') //Go north
            {
                if (map[GetXPosition() - 1, GetYPosition()].GetDanger()) //Checks if tile is dangerous
                {
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
                    else if (SuperKeys > 0)
                    {
                        UsedKey = true;
                        SuperKeys--;
                        map[GetXPosition() - 1, GetYPosition()].SetSolid(false);
                    }
                    else //Player needs a key
                    {
                        NeedKey = true;
                    }
                }
                if (!map[GetXPosition() - 1, GetYPosition()].IsSolid()) //Checks if tile is solid
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition() - 1, GetYPosition()];
                    if (temp is Key) //Checks if tile is key
                    {
                        GotKey = true;
                        temp = new Floor(true);
                        Keys++;
                    }
                    if (temp is SuperKey) //Checks if tile is superkey
                    {
                        GotSuperKey = true;
                        temp = new Floor(true);
                        SuperKeys+=3;
                    }
                    if (temp is Exit) //Checks if tile is exit
                    {
                        PlayerWin = true;
                    }
                    if (temp is Mud) //Checks if tile is mud
                    {
                        SteppedInMud = true;
                    }
                    map[GetXPosition() - 1, GetYPosition()] = player;
                    SetXPosition(GetXPosition() - 1);
                    map = ExpandVision(map, player); //Update visibility
                }
            }
            if (input == 's') //Go south
            {
                if (map[GetXPosition() + 1, GetYPosition()].GetDanger()) //Checks if tile is dangerous
                {
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
                    else if (SuperKeys > 0)
                    {
                        UsedKey = true;
                        SuperKeys--;
                        map[GetXPosition() + 1, GetYPosition()].SetSolid(false);
                    }
                    else //Player needs a key
                    {
                        NeedKey = true;
                    }
                }
                if (!map[GetXPosition() + 1, GetYPosition()].IsSolid()) //Checks if tile is solid
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition() + 1, GetYPosition()];
                    if (temp is Key) //Checks if tile is key
                    {
                        GotKey = true;
                        temp = new Floor(true);
                        Keys++;
                    }
                    if (temp is SuperKey) //Checks if tile is superkey
                    {
                        GotKey = true;
                        temp = new Floor(true);
                        SuperKeys += 3;
                    }
                    if (temp is Exit) //Checks if tile is Exit
                    {
                        PlayerWin = true;
                    }
                    if (temp is Mud) //Checks if tile is mud
                    {
                        SteppedInMud = true;
                    }
                    map[GetXPosition() + 1, GetYPosition()] = player;
                    SetXPosition(GetXPosition() + 1);
                    map = ExpandVision(map, player); //Update visibility
                }
            }
            if (input == 'a') //Go west
            {
                if (map[GetXPosition(), GetYPosition() - 1].GetDanger()) //Checks if tile is dangerous
                {
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
                    else if (SuperKeys > 0)
                    {
                        UsedKey = true;
                        SuperKeys--;
                        map[GetXPosition(), GetYPosition() - 1].SetSolid(false);
                    }
                    else //Player needs a key
                    {
                        NeedKey = true;
                    }
                }
                if (!map[GetXPosition(), GetYPosition() - 1].IsSolid()) //Checks if tile is solid
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition(), GetYPosition() - 1];
                    if (temp is Key) //Checks if tile is key
                    {
                        GotKey = true;
                        temp = new Floor(true);
                        Keys++;
                    }
                    if (temp is SuperKey) //Checks if tile is superkey
                    {
                        GotKey = true;
                        temp = new Floor(true);
                        SuperKeys += 3;
                    }
                    if (temp is Exit) //Checks if tile is exit
                    {
                        PlayerWin = true;
                    }
                    if (temp is Mud) //Checks if tile is mud
                    {
                        SteppedInMud = true;
                    }
                    map[GetXPosition(), GetYPosition() - 1] = player;
                    SetYPosition(GetYPosition() - 1);
                    map = ExpandVision(map, player); //Update visibility
                }
            }
            if (input == 'd') //Go east
            {
                if (map[GetXPosition(), GetYPosition() + 1].GetDanger()) //Checks if tile is dangerous
                {
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
                    else if (SuperKeys > 0)
                    {
                        UsedKey = true;
                        SuperKeys--;
                        map[GetXPosition(), GetYPosition() + 1].SetSolid(false);
                    }
                    else //Player needs a key
                    {
                        NeedKey = true;
                    }
                }
                if (!map[GetXPosition(), GetYPosition() + 1].IsSolid()) //Checks if tile is solid
                {
                    map[XPosition, YPosition] = temp;
                    temp = map[GetXPosition(), GetYPosition() + 1];
                    if (temp is Key) //Checks if tile is key
                    {
                        GotKey = true;
                        temp = new Floor(true);
                        Keys++;
                    }
                    if (temp is SuperKey) //Checks if tile is superkey
                    {
                        GotKey = true;
                        temp = new Floor(true);
                        SuperKeys += 3;
                    }
                    if (temp is Exit) //Checks if object is exit
                    {
                        PlayerWin = true;
                    }
                    if (temp is Mud) //Checks if tile is mud
                    {
                        SteppedInMud = true;
                    }
                    map[GetXPosition(), GetYPosition() + 1] = player;
                    SetYPosition(GetYPosition() + 1);
                    map = ExpandVision(map, player); //Update visibility
                }
            }
            return map;
        }
        public Tile[,] ExpandVision(Tile[,] map, Player player)
        {
            for (int i = player.XPosition - 2; i < player.XPosition + 3; i++)
            {
                for (int j = player.YPosition - 2; j < player.YPosition + 3; j++)
                {
                    if (i >= 0 && i < map.GetUpperBound(0) && j > 0)
                    {
                        if (!map[i, j].IsVisible())
                        {
                            map[i, j].MakeVisible();
                        }
                    }
                }
            }
            return map;
        }
    }
}
