using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Models
{
    public class Settlement
    {
        public string name;
        public int level;
        public int population;
        public double lifeQuality;
        public List<Tuple<int, int>> locations;
        public int settlementID;

        public Settlement(string name, int level, int population, Tuple<int, int> location, int settlementID)
        {
            locations = new List<Tuple<int, int>>();
            this.name = name;
            this.level = level;
            this.population = population;
            this.lifeQuality = 1;
            this.locations.Add(location);
            this.settlementID = settlementID;
        }
    }
}
