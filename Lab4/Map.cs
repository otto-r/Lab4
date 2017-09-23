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
        static string MapCurrent = Properties.Resources.TestMap;

        public static Object[,] GenerateMap()
        {
            Console.WriteLine("     Map:");
            Console.WriteLine("(1) Map:");
            Console.WriteLine("(2) TestMap:");

            string input = Console.ReadLine();
            if (input == "1")
            {
                MapCurrent = Properties.Resources.Map;
            }
            else if (input == "2")
            {
                MapCurrent = Properties.Resources.TestMap;
            }

            Console.Clear();

            String MapString = MapCurrent;
            String MapString2 = MapString.Replace(Environment.NewLine, "");
            int rows = ((MapString.Length - MapString2.Length) / 2 + 1);
            int columns = (MapString2.Length / rows);
            Console.WriteLine($"Mapstring: {MapString.Length} Mapstring2: {MapString2.Length}, Rows: {rows} Columns: {columns}");
            Object[,] map = new Object[rows, columns];

            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (MapString2[counter] == '#')
                    {
                        map[i, j] = new Wall();
                    }
                    else if (MapString2[counter] == 'D')
                    {
                        map[i, j] = new Door();
                    }
                    else if (MapString2[counter] == '-')
                    {
                        map[i, j] = new Floor();
                    }
                    else if (MapString2[counter] == 'k')
                    {
                        map[i, j] = new Key();
                    }
                    else if (MapString2[counter] == 'x')
                    {
                        map[i, j] = new Void();
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
