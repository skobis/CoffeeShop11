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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController (IClientService clientService)
        {
            _clientService = clientService;
        }
        // GET: api/Client
        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            return _clientService.GetClients();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");

            var clientFound = _clientService.FindByID(id);
            if (clientFound.ID != id)
            {
                return BadRequest("ID is not correct.");
            }
            
            return Ok(clientFound);
        }

        // POST: api/Client
        [HttpPost]
        public ActionResult<Client> Post([FromBody] Client client)
        {
            if(client.Name == null)
            {
                return BadRequest("Client can't be added without a Name!");
            }
            if (client.BirthDate == null)
            {
                return BadRequest("Client can't be added without a BirthDate!");
            }
            if (client.BillingAddress == null)
            {
                return BadRequest("Client can't be added without an Address");
            }
            if (client.PassWord == null)
            {
                return BadRequest("Client can't be added without a Password!");
            }

            _clientService.SaveOwner(client);
            return Ok($"Client with Name: {client.Name} was Added");
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public ActionResult<Client> Put (int id, [FromBody] Client client)
        {
            if (client.Name == null)
            {
                return BadRequest("Client can't be added without a Name!");
            }
            if (client.BirthDate == null)
            {
                return BadRequest("Client can't be added without a BirthDate!");
            }
            if (client.BillingAddress == null)
            {
                return BadRequest("Client can't be added without an Address");
            }
            if (client.PassWord == null)
            {
                return BadRequest("Client can't be added without a Password!");
            }

            return _clientService.UpdateOwner(client);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Client> Delete (int id)
        {
            Client clientDeleted = new Client();
            try
            {
                clientDeleted = _clientService.Delete(id);
            }
            catch
            {
                return BadRequest("Client can't be deleted while an order is active!");
            }
            
            return Ok($"Client with Name: {clientDeleted.Name} was Deleted!");
        }
    }
}
