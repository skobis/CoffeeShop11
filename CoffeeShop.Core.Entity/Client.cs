using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Core.Entity
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string BillingAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Order> Orders { get; set; }
    }
}
