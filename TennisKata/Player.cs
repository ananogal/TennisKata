using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisKata
{
    public class Player
    {
        int points = 0;

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public string Name { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public void AddPoint()
        {
            this.points += 1;
        }

        public bool HasMoreThanThreePoints()
        {
            return this.points > 3;
        }

        
    }
}
