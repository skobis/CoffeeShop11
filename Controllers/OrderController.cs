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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController (IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return _orderService.GetAllOrders();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");

            var orderFound = _orderService.FindOrderByID(id);
            return Ok(orderFound);
        }

        // POST: api/Order
        [HttpPost]
        public ActionResult<Client> Post([FromBody] Order order)
        {
            if (order.Client == null)
            {
                return BadRequest("Order cannot be posted without a Client!");
            }
            if(order.OrderedItem == null)
            {
                return BadRequest("Order cannot be posted without an ordered Item!");
            }
            
            _orderService.SaveOrder(order);
            return Ok($"Order with ID: {order.ID} was Recieved");
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order order)
        {
            if (order.Client == null)
            {
                return BadRequest("Order cannot be posted without a Client!");
            }
            if (order.OrderedItem == null)
            {
                return BadRequest("Order cannot be posted without an ordered Item!");
            }

            var orderUpdate = _orderService.FindOrderByID(id);
            orderUpdate = _orderService.UpdateOrder(order);
            return Ok($"{orderUpdate.Client}'s order with ID: {orderUpdate.ID} was Updated!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {
            var orderDeleted = _orderService.DeleteOrder(id);
            return Ok($"{orderDeleted.Client}'s order with ID: {orderDeleted.ID} was Deleted");
        }
    }
}
