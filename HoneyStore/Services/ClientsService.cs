using HoneyStore.Dto;
using HoneyStore.Models;
using HoneyStore.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace HoneyStore.Services
{
    public class ClientsService
    {
        private readonly HoneyStoreContext _context;
        private readonly IConfiguration _configuration;

        public ClientsService(HoneyStoreContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        public IActionResult Register(RegisterDto register)
        {
            if(register == null || register.Address == null)
            {
                return new BadRequestResult();
            }

            var client = new Client
            {
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Password = Hash.GetHash(register.Password),
                Address = new Address()
                {
                    City = register.Address.City,
                    StreetAndHomeNumber = register.Address.StreetAndHomeNumber,
                    PostCode = register.Address.PostCode
                }
            };

            if (!_context.Clients.Any(x => (x.Email == client.Email)))
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return new OkResult();
            }

            return new ConflictResult();
        }

        public ActionResult<IEnumerable<ClientDto>> GetClients()
        {
            return _context.Clients.Select(x => new ClientDto
            {
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();
        }

        public UserDto Login(LoginDto login)
        {
            var hash = Hash.GetHash(login.Password);

            if (!_context.Clients.Any(x => x.Email == login.Email))
            {
                return null;
            }

            var user = _context.Clients.Single(x => x.Email == login.Email);

            if (user.Password == hash)
            {
                return new UserDto
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = Token.GenerateToken(user.Email, user.FirstName, user.LastName, _configuration),
                };
            }
            return null;
        }
    }
}
