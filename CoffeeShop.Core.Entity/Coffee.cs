using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Core.Entity
{
    public class Coffee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Prise { get; set; }
        public string Country { get; set; }
    }
}
