using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeShop.Core.DomainService;
using CoffeeShop.Core.Entity;

namespace CoffeeShop.Core.AppService.Services.Implementation
{
    public class ClientsService : IClientService
    {
        readonly IClientRepository _clientRepo;

        public ClientsService (IClientRepository clientRepository)
        {
            _clientRepo = clientRepository;
        }

        public List<Client> GetClients()
        {
            return _clientRepo.ReadAll().ToList();
        }

        public Client NewOwner(string Name, string Password, string BillingAddress, DateTime BirthDate)
        {
            var client = new Client()
            {
                Name = Name,
                PassWord = Password,
                BillingAddress = BillingAddress,
                BirthDate = BirthDate
            };
            return client;
        }

        public Client SaveOwner(Client client)
        {
            return _clientRepo.NewClient(client);
        }
        public Client Delete(int id)
        {
           return _clientRepo.Delete(id);
        }

        public Client FindByID(int id)
        {
            return _clientRepo.Delete(id);
        }

        public Client UpdateOwner(Client clientUpdate)
        {
            return _clientRepo.Update(clientUpdate);
        }
    }
}
