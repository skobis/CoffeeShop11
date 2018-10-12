using CoffeeShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Core.AppService
{
    public interface IOrderService
    {
        Order DeleteOrder(int id);
        Order NewOrder(Client client, DateTime date, Coffee OrderedItem);
        Order SaveOrder(Order order);
        Order UpdateOrder(Order OrderUpdate);
        Order FindOrderByID(int id);
        List<Order> GetAllOrders();
    }
}
