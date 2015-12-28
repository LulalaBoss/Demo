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
        private List<Settlement> settlements;
        private NameGenerator generator;
        private int updateTicks;

        public GameState(string name, int cash)
        {
            updateTicks = 0;
            generator = new NameGenerator();

            store = new Store(name, cash, 6, 4);

            // adding settlements
            settlements = new List<Settlement>();

            var settlement = new Settlement("Kleshi", 1, 130);
            settlements.Add(settlement);
        }

        public int getStoreCash() { return store.cash; }
        public string getStoreName() { return store.name; }
        public int getCustomerCountInStore() { return store.tables.Count; }
        public int getCustomerCountInLine() { return store.line.Count; }
        public string getCurrentSettlementName() { return settlements[0].name; }
       

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

                if (customer != null)
                {
                    store.usheringCustomer(customer);
                    isFlash = true;
                    updateTicks = 0;
                }              
            }

            if (isFlash && updateTicks>2000)
            {
                isFlash = false;
            }
        }

        public Customer generateCustomer()
        {
            Customer customer = null;

            if (shouldGenerateCustomer())
            {
                customer = new Customer { firstName = generator.getFirstName(), lastName = generator.getLastName() };
            }

            return customer;
        }

        public bool shouldGenerateCustomer() 
        {
            Random random = new Random();
            var r = random.Next(0, 100);

            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
