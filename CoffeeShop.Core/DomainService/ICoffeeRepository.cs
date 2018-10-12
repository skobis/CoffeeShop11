using CoffeeShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Core.DomainService
{
    public interface ICoffeeRepository
    {
        Coffee NewCoffee(Coffee coffee);
        Coffee ReadByID(int id);
        IEnumerable<Coffee> ReadAll();
        Coffee Delete(int id);
        Coffee Update(Coffee ownerUpdate);
    }
}
