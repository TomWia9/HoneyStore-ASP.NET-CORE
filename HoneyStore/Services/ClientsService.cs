using HoneyStore.Dto;
using HoneyStore.Models;
using HoneyStore.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyStore.Services
{
    public class ClientsService
    {
        private readonly HoneyStoreContext _context;

        public ClientsService(HoneyStoreContext context)
        {
            _context = context;
        }

        public IActionResult Register(RegisterDto register)
        {
            var client = new Client
            {
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Password = Hash.GetHash(register.Password)
            };

            if (!_context.Clients.Any(x => (x.Email == client.Email)))
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return new OkResult();
            }

            return new ConflictResult();
        }

        public ActionResult<IEnumerable<Client>> GetClients() => _context.Clients;
    }
}
