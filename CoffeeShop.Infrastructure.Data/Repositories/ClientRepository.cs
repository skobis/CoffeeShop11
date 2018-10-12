using CoffeeShop.Core.DomainService;
using CoffeeShop.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeShop.Infrastructure.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        readonly CoffeeShopAppContext _ctx;

        public ClientRepository(CoffeeShopAppContext ctx)
        {
            _ctx = ctx;
        }
        public Client NewClient(Client client)
        {
            var cl = _ctx.Clients.Add(client).Entity;

            _ctx.SaveChanges();
            return cl;
        }
        public IEnumerable<Client> ReadAll()
        {
            return _ctx.Clients;
        }
        public Client ReadByID(int id)
        {
            var cl = _ctx.Clients.FirstOrDefault(c => c.ID == id);

            if(cl == null)
            {
                return null;
            }

            cl.Orders = GetOrdersByClient(cl);
            return cl;
        }

        public List<Order> GetOrdersByClient(Client client)
        {
            if(client == null)
            {
                return null;
            }

            return _ctx.Orders.Where(o => o.Client.ID == client.ID).ToList();
        }

        public Client Delete(int id)
        {
            Client clToRemove = ReadByID(id);
            _ctx.Clients.Remove(clToRemove);

            _ctx.SaveChanges();
            return clToRemove;
        }
        
        public Client Update(Client ownerUpdate)
        {
            _ctx.Attach(ownerUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return ownerUpdate;
        }
    }
}
