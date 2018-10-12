using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeShop.Core.DomainService;
using CoffeeShop.Core.Entity;

namespace CoffeeShop.Core.AppService.Services.Implementation
{
    public class OrderService : IOrderService
    {
        public IOrderRepository _orderRepo;
        public ICoffeeRepository _coffeeRepo;
        public IClientRepository _clientRepo;

        public OrderService(IOrderRepository orderRepository,
            ICoffeeRepository coffeeRepository, IClientRepository clientRepository)
        {
            _orderRepo = orderRepository;
            _clientRepo = clientRepository;
            _coffeeRepo = coffeeRepository;
               
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.ReadAll().ToList();
        }

        public Order NewOrder(Client client, DateTime date, Coffee OrderedItem)
        {
            var order = new Order()
            {
                Client = client,
                Date = date,
                OrderedItem = OrderedItem
            };
            return order;
        }

        public Order SaveOrder(Order order)
        {
            return _orderRepo.NewOrder(order);
        }

        public Order DeleteOrder(int id)
        {
            return _orderRepo.Delete(id);
        }

        public Order FindOrderByID(int id)
        {
            return _orderRepo.ReadByID(id);
        }
        
        public Order UpdateOrder(Order OrderUpdate)
        {
            return _orderRepo.Update(OrderUpdate);
        }

    }
}
