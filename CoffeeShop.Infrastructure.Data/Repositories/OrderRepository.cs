using CoffeeShop.Core.DomainService;
using CoffeeShop.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeShop.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly CoffeeShopAppContext _ctx;

        public OrderRepository(CoffeeShopAppContext ctx)
        {
            _ctx = ctx;
        }
        public Order NewOrder(Order order)
        {
            var ord = _ctx.Orders.Add(order).Entity;

            order.Date = DateTime.Now;
            _ctx.SaveChanges();
            return ord;
        }

        public IEnumerable<Order> ReadAll()
        {
            return _ctx.Orders;
        }
        
        public Order ReadByID(int id)
        {
            return _ctx.Orders.Include(o => o.Client)
                .Include(o => o.OrderedItem)
                .FirstOrDefault(c => c.ID == id);
        }
        
        public Order Delete(int id)
        {
            Order orderToRemove = ReadByID(id);
            _ctx.Orders.Remove(orderToRemove);

            _ctx.SaveChanges();
            return orderToRemove;
        }
        
        public Order Update(Order orderUpdate)
        {
            _ctx.Attach(orderUpdate).State = EntityState.Modified;
            _ctx.Entry(orderUpdate).Reference(o => o.OrderedItem).IsModified = true;
            _ctx.SaveChanges();
            return orderUpdate;
        }
    }
}
