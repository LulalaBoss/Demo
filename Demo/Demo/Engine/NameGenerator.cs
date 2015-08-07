using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Engine
{
    public class NameGenerator
    {
        private Dictionary<int,string> lastNames;
        private Dictionary<int,string> firstNames;

        public NameGenerator()
        {
            lastNames = new Dictionary<int, string>();
            firstNames = new Dictionary<int, string>();

            loadDictionaries();
        }

        private void loadDictionaries()
        {
            lastNames.Add(0, "LeBlanc");
            lastNames.Add(1, "Watson");
            lastNames.Add(2, "Goob");
            lastNames.Add(3, "Hu");
            lastNames.Add(4, "Venitori");

            firstNames.Add(0, "Nancy");
            firstNames.Add(1, "Leo");
            firstNames.Add(2, "Susan");
            firstNames.Add(3, "Elizabeth");
            firstNames.Add(4, "Kevin");
        }

        public string getLastName()         
        {
            Random rand = new Random();
            return lastNames.ElementAt(rand.Next(0, lastNames.Count)).Value;
        }

        public string getFirstName()
        {
            Random rand = new Random();
            return firstNames.ElementAt(rand.Next(0, firstNames.Count)).Value;
        }
    }
}
