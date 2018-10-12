using CoffeeShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Core.AppService
{
    public interface IClientService
    {
        List<Client> GetClients();
        Client UpdateOwner(Client clientUpdate);
        Client NewOwner(string Name, string Password, string BillingAddress, DateTime BirthDate);
        Client SaveOwner(Client client);
        Client FindByID(int id);
        Client Delete(int id);
    }
}
