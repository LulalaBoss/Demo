using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Models
{
    public class Store
    {
        public string name { get; set; }
        public int cash { get; set; }

        public int tableNumber { get; set; }
        public int lineSize { get; set; }

        public List<Customer> tables { get; set; }
        public List<Customer> line { get; set; }

        public Store(string name, int cash, int lineSize, int tableNumber)
        {
            this.name = name;
            this.cash = cash;
            this.tableNumber = tableNumber;
            this.lineSize = lineSize;
            tables = new List<Customer>(tableNumber);
            line = new List<Customer>(lineSize);
        }

        public void usheringCustomer(Customer customer) 
        {
            // check if there are available tables. If it does, fill it
            if (tables.Count < tableNumber)
            {
                tables.Add(customer);
            }
            // else put them in the waiting line, if it's not full
            else if (line.Count < lineSize)
            {
                line.Add(customer);
            }
            // the line is too long! Customer is gone
        }



    }
}
