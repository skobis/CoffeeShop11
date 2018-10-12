using CoffeeShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Core.DomainService
{
    public interface IClientRepository
    {
        Client NewClient(Client client);
        Client ReadByID(int id);
        IEnumerable<Client> ReadAll();
        Client Delete(int id);
        Client Update(Client ownerUpdate);
    }
}
