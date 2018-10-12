using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Core.AppService;
using CoffeeShop.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeService _coffeeService;

        public CoffeeController (ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        // GET: api/Coffee
        [HttpGet]
        public ActionResult<IEnumerable<Coffee>> Get()
        {
            return _coffeeService.ReadAll().ToList();
        }

        // GET: api/Coffee/5
        [HttpGet("{id}")]
        public ActionResult<Coffee> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");

            var coffeeFound = _coffeeService.ReadByID(id);
            return Ok(coffeeFound);
        }

        // POST: api/Coffee
        [HttpPost]
        public ActionResult<Coffee> Post([FromBody] Coffee coffee)
        {
            if(coffee.Name == null)
            {
                return BadRequest("Product can't be added without a Name!");
            }
            if (coffee.Category == null)
            {
                return BadRequest("Product can't be added if not part of any Category!");
            }
            if (coffee.Country == null)
            {
                return BadRequest("Product must have an origin country!");
            }
            if (coffee.Prise.Equals(null))
            {
                return BadRequest("Product can't be Free!");
            }

            _coffeeService.SaveCoffee(coffee);
            return Ok($"Item with Name: {coffee.Name} was Added");
        }

        // PUT: api/Coffee/5
        [HttpPut("{id}")]
        public ActionResult<Coffee> Put(int id, [FromBody] Coffee coffee)
        {
            if (coffee.Name == null)
            {
                return BadRequest("Product can't be added without a Name!");
            }
            if (coffee.Category == null)
            {
                return BadRequest("Product can't be added if not part of any Category!");
            }
            if (coffee.Country == null)
            {
                return BadRequest("Product must have an origin country!");
            }
            if (coffee.Prise.Equals(null))
            {
                return BadRequest("Product can't be Free!");
            }

            var coffeeUpdate = _coffeeService.ReadByID(id);
            coffeeUpdate = _coffeeService.Update(coffee);
            return Ok($"Client with Name: {coffeeUpdate.Name} was Updated!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Coffee> Delete(int id)
        {
            var coffeeDeleted = new Coffee();

            try
            {
                coffeeDeleted = _coffeeService.Delete(id);

            }
            catch
            {
                return BadRequest("The product you are trying to delete is present in an unfulfilled order! Please fulfille the orders to delete the Product!");
            }
            
            return Ok($"Client with Name: {coffeeDeleted.Name} was Deleted!");
        }
    }
}
