using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class HighScore
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Id { get; set; }

        public HighScore(string name, int score, int id)
        {
            Name = name;
            Score = score;
            Id = id;
        }
    }
}
