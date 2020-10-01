using System.Collections.Generic;
using HoneyStore.Dto;
using HoneyStore.Models;
using HoneyStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HoneyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsService clientsService;

        public ClientsController(HoneyStoreContext context, IConfiguration configuration)
        {
            clientsService = new ClientsService(context, configuration);
        }

        [HttpPost("Register")]
        public ActionResult Register(RegisterDto register)
        {
            return clientsService.Register(register);
        }

        [HttpPost("Login")]
        public UserDto Login(LoginDto user)
        {
            return clientsService.Login(user);
        }

       // [Authorize]
        [HttpGet("GetClients")]
        public ActionResult<IEnumerable<ClientDto>> GetClients()
        {
            return clientsService.GetClients();
        }

        [HttpGet("GetClient/{clientId}")]
        public ActionResult<ClientDto> GetClient(int clientId)
        {
            return clientsService.GetClient(clientId);
        }

        [HttpGet("GetClientAddress/{clientId}")]
        public ActionResult<AddressDto> GetClientAddress(int clientId)
        {
            return clientsService.GetClientAddress(clientId);
        }

        [HttpPut("ChangeClientAddress/{clientId}")]
        public IActionResult ChangeClientAddress(int clientId, AddressDto address)
        {
            return clientsService.ChangeClientAddress(clientId, address);
        }

        [HttpPatch("ChangeClientPassword/{clientId}")]
        public IActionResult ChangeClientPassword(int clientId, string newPassword)
        {
            return clientsService.ChangeClientPassword(clientId, newPassword);
       
        }
    }
}
