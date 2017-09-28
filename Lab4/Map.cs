using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab4
{
    public static class Map
    {
        static string MapCurrent;

        public static Tile[,] GenerateMap() //This class generates the map from text file and translates it into the tiles subclasses
        {
            Console.WriteLine("     Map:");
            Console.WriteLine("(1) Map:");
            Console.WriteLine("(2) TestMap:");

            char input;
            while (true) //Waits for legit input
            {
                input = Console.ReadKey(true).KeyChar; //Get input
                if (input == '1' || input == '2')
                {
                    break;
                }
            }
            if (input == '1')
            {
                MapCurrent = Properties.Resources.Map;
            }
            else if (input == '2')
            {
                MapCurrent = Properties.Resources.TestMap;
            }

            Console.Clear();

            String MapString = MapCurrent;
            String MapString2 = MapString.Replace(Environment.NewLine, "");
            int rows = ((MapString.Length - MapString2.Length) / 2 + 1);
            int columns = (MapString2.Length / rows);
            Tile[,] map = new Tile[rows, columns];

            int counter = 0;
            for (int i = 0; i < rows; i++)  //translates the symbols to object, puts in array
            {
                for (int j = 0; j < columns; j++)
                {
                    if (MapString2[counter] == '#')
                    {
                        map[i, j] = new Wall(false);
                    }
                    else if (MapString2[counter] == '%')
                    {
                        map[i, j] = new Wall(true);
                    }
                    else if (MapString2[counter] == 'D')
                    {
                        map[i, j] = new Door();
                    }
                    else if (MapString2[counter] == '-')
                    {
                        map[i, j] = new Floor(false);
                    }
                    else if (MapString2[counter] == 'k')
                    {
                        map[i, j] = new Key();
                    }
                    else if (MapString2[counter] == 'K')
                    {
                        map[i, j] = new SuperKey();
                    }
                    else if (MapString2[counter] == 'x')
                    {
                        map[i, j] = new Void();
                    }
                    else if (MapString2[counter] == 'O')
                    {
                        map[i, j] = new Exit();
                    }
                    else if (MapString2[counter] == '~')
                    {
                        map[i, j] = new Mud();
                    }
                    else if (MapString2[counter] == '^')
                    {
                        map[i, j] = new Fire();
                    }
                    else if (MapString2[counter] == '/')
                    {
                        map[i, j] = new Lever();
                    }
                    else if (MapString2[counter] == 'b')
                    {
                        map[i, j] = new Boots();
                    }
                    else if (MapString2[counter] == 'j')
                    {
                        map[i, j] = new Jacket();
                    }
                    counter++;
                }
            }
            return map;
        }
        public static int GetRows()
        {
            String MapString = MapCurrent;
            String MapString2 = MapString.Replace(Environment.NewLine, "");
            int rows = ((MapString.Length - MapString2.Length) / 2 + 1);
            return rows;
        }
        public static int GetColumns()
        {
            String MapString = MapCurrent;
            String MapString2 = MapString.Replace(Environment.NewLine, "");
            int rows = ((MapString.Length - MapString2.Length) / 2 + 1);
            int columns = (MapString2.Length / rows);
            return columns;
        }
    }
}
