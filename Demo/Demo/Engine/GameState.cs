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
        private NameGenerator generator;
        private int updateTicks;

        public GameState(string name, int cash)
        {
            updateTicks = 0;
            generator = new NameGenerator();

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
        public int getCustomerCountInStore() { return store.tables.Count; }
        public int getCustomerCountInLine() { return store.line.Count; }

        public string getCustomerInStoreList() 
        {
            var list = "";
            foreach (var c in store.tables)
            {
                list = list + " " + c.firstName + " " + c.lastName;
            }
            return list; 
        }
        public string getCustomerInLineList() 
        {
            var list = "";
            foreach (var c in store.line)
            {
                list = list + " " + c.firstName + " " + c.lastName;
            }
            return list; 
        }

        public void update(int elapsedTicks, ref bool isFlash)
        {
            updateTicks += elapsedTicks;
            if (updateTicks > 3000)
            {
                var customer = generateCustomer();
                store.usheringCustomer(customer);

                isFlash = true;
                updateTicks = 0;
            }

            if (isFlash && updateTicks>2000)
            {
                isFlash = false;
            }
        }

        public Customer generateCustomer()
        {
            var customer = new Customer { firstName = generator.getFirstName(), lastName = generator.getLastName() };
            return customer;
        }

    }
}
