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
        private int updateTicks;

        public GameState(string name, int cash)
        {
            updateTicks = 0;

            store = new Store 
            {
                name = name, 
                cash = cash,
                tableNumber = 4,
                lineSize = 6,
                tables = new List<Customer>(),
                line = new List<Customer>()
            };
        }

        public int getStoreCash() { return store.cash; }
        public string getStoreName() { return store.name; }

        public void update(int elapsedTicks, ref bool isFlash)
        {
            updateTicks += elapsedTicks;
            if (updateTicks > 5000)
            {
                isFlash = true;
                updateTicks = 0;
            }

            if (isFlash && updateTicks>2000)
            {
                isFlash = false;
            }
        }

    }
}
