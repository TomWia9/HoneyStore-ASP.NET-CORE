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
        public ActionResult Register(RegisterDto register)
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
                    StreetAndHouseNumber = register.Address.StreetAndHouseNumber,
                    PostCode = register.Address.PostCode
                },
                HoneysInTheCart = new List<HoneyItem>(),
            };

            if (!_context.Clients.Any(x => x.Email == client.Email))
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

        public ActionResult<ClientDto> GetClient(int clientId)
        {
            var client = _context.Clients.FirstOrDefault(x => x.Id == clientId);

            if (client == null)
                return new NotFoundResult();

            return new ClientDto()
            {
                Email = client.Email,
                FirstName = client.FirstName,
                LastName = client.LastName
            };
        }

        public ActionResult<AddressDto> GetClientAddress(int clientId)
        {
            if (!_context.Clients.Any(x => x.Id == clientId))
                return new NotFoundResult();

            var address = _context.Addresses.Where(x => x.ClientId == clientId).FirstOrDefault();

            return new AddressDto()
            {
                City = address.City,
                StreetAndHouseNumber = address.StreetAndHouseNumber,
                PostCode = address.PostCode
            };
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
                    Id = user.Id,
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
