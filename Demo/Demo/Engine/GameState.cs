using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Models;

namespace Demo.Engine
{
    public class GameState
    {
        private Store store;

        public GameState(string name, int cash)
        {
            store = new Store { name = name, cash = cash };
        }

        public int getStoreCash() { return store.cash; }
        public string getStoreName() { return store.name; }
    }
}
