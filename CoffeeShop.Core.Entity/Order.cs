using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Core.Entity
{
    public class Order
    {
        public int ID { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public Coffee OrderedItem { get; set; }
    }
}
