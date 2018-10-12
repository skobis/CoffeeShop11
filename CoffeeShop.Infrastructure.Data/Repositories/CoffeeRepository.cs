using CoffeeShop.Core.DomainService;
using CoffeeShop.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeShop.Infrastructure.Data.Repositories
{
    public class CoffeeRepository : ICoffeeRepository
    {
        readonly CoffeeShopAppContext _ctx;

        public CoffeeRepository(CoffeeShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Coffee NewCoffee(Coffee coffee)
        {
            var cof = _ctx.Coffees.Add(coffee).Entity;

            _ctx.SaveChanges();
            return cof;
        }

        public IEnumerable<Coffee> ReadAll()
        {
            return _ctx.Coffees;
        }

        public Coffee ReadByID(int id)
        {
            var cof = _ctx.Coffees.FirstOrDefault(c => c.ID == id);

            if (cof == null)
            {
                return null;
            }

            return cof;
        }

        public Coffee Delete(int id)
        {
            Coffee coffeeToRemove = ReadByID(id);
            _ctx.Coffees.Remove(coffeeToRemove);

            _ctx.SaveChanges();
            return coffeeToRemove;
        }

        public Coffee Update(Coffee ownerUpdate)
        {
            _ctx.Attach(ownerUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return ownerUpdate;
        }
    }
}
