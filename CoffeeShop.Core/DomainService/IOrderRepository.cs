using CoffeeShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Core.DomainService
{
    public interface IOrderRepository
    {
        Order NewOrder(Order order);
        Order ReadByID(int id);
        IEnumerable<Order> ReadAll();
        Order Delete(int id);
        Order Update(Order ownerUpdate);
    }
}
