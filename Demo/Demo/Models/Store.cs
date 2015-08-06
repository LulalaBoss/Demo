using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Models
{
    public class Store
    {
        public string name;
        public int cash;

        public Store(string name, int cash)
        {
            this.name = name;
            this.cash = cash;
        }
    }
}
