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

        public Settlement(string name, int level, int population)
        {
            this.name = name;
            this.level = level;
            this.population = population;
            this.lifeQuality = 1; 
        }
    }
}
