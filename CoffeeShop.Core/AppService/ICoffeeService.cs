using CoffeeShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Core.AppService
{
    public interface ICoffeeService
    {
        Coffee NewCoffee(string category, double Prise, string country);
        Coffee SaveCoffee(Coffee coffee);
        Coffee ReadByID(int id);
        IEnumerable<Coffee> ReadAll();
        Coffee Delete(int id);
        Coffee Update(Coffee ownerUpdate);
    }
}
