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
        private bool GotBoots;
        private bool PlayerWin;
        private bool SteppedInMud;
        private bool PulledLever;
        private int Keys;
        private int SuperKeys;
        private Tile Gear;
        private Tile temp;

        public Player()
        {
            XPosition = 2;
            YPosition = 2;
            Symbol = (char)Objects.Player;
            Solid = true;
            Visible = true;
            Gear = new Floor(true);
            temp = new Floor(true);
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
            PulledLever = false;
            GotBoots = false;
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

        public bool GetPulledLever()
        {
            return PulledLever;
        }

        public bool GetGotBoots()
        {
            return GotBoots;
        }

        public Tile GetGear()
        {
            return Gear;
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
                    temp = CheckTile(temp); // Checks for special tile
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
                    temp = CheckTile(temp); // Checks for special tile
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
                    temp = CheckTile(temp); // Checks for special tile
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
                    temp = CheckTile(temp); // Checks for special tile
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
                    if (i >= 0 && i < map.GetUpperBound(0) && j > 0 && j < map.GetUpperBound(0)) //fix upperbound on j
                    {
                        if (!map[i, j].IsVisible())
                        {
                            if (i == (player.XPosition - 2) && map[player.XPosition - 1, j] is Wall)    //no visibility north
                            {

                            }
                            else if (i == (player.XPosition + 2) && map[player.XPosition + 1, j] is Wall)   //no visibility south
                            {

                            }
                            else if (j == (player.YPosition - 2) && map[i, player.YPosition - 1] is Wall)
                            {

                            }
                            else if (j == (player.YPosition + 2) && map[i, player.YPosition + 1] is Wall)
                            {

                            }
                            else
                            {
                                map[i, j].MakeVisible();
                            }
                        }
                    }
                }
            }
            return map;
        }
    public Tile CheckTile(Tile tile)
        {
            if (tile is Key) //Checks if tile is key
            {
                GotKey = true;
                tile = new Floor(true);
                Keys++;
            }
            else if (tile is SuperKey) //Checks if tile is superkey
            {
                GotSuperKey = true;
                tile = new Floor(true);
                SuperKeys += 3;
            }
            else if (tile is Exit) //Checks if tile is exit
            {
                PlayerWin = true;
            }
            else if (tile is Mud) //Checks if tile is mud
            {
                SteppedInMud = true;
            }
            else if (tile is Lever && !temp.IsPulled()) //Checks if tile is lever
            {
                tile.PullLever();
                PulledLever = true;
            }
            else if (tile is Boots) //Checks if tile is boots
            {
                GotBoots = true;
                Gear = tile;
                tile = new Floor(true);
            }
            return tile;
        }
    }
}
