using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeShop.Core.DomainService;
using CoffeeShop.Core.Entity;

namespace CoffeeShop.Core.AppService.Services.Implementation
{
    public class CoffeeService : ICoffeeService
    {
        readonly ICoffeeRepository _coffeeRepository;

        public CoffeeService (ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }
        public Coffee Delete(int id)
        {
            return _coffeeRepository.Delete(id);
        }

        public Coffee SaveCoffee(Coffee coffee)
        {
            return _coffeeRepository.NewCoffee(coffee);
        }

        public Coffee NewCoffee(string category, double Prise, string country)
        {
            var coffee = new Coffee()
            {
                Category = category,
                Prise = Prise,
                Country = country
            };
            return coffee;
        }

        public IEnumerable<Coffee> ReadAll()
        {
            return _coffeeRepository.ReadAll().ToList();
        }

        public Coffee ReadByID(int id)
        {
            return _coffeeRepository.ReadByID(id);
        }


        public Coffee Update(Coffee coffeeUpdate)
        {
            return _coffeeRepository.Update(coffeeUpdate);
        }
    }
}
