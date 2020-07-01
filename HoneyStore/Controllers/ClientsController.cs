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
        public IActionResult Register(RegisterDto register)
        {
            return clientsService.Register(register);
        }

        [HttpPost("Login")]
        public UserDto Login(LoginDto user)
        {
            return clientsService.Login(user);
        }

        [Authorize]
        [HttpGet("GetClients")]
        public ActionResult<IEnumerable<ClientDto>> GetClients()
        {
            return clientsService.GetClients();
        }
    }
}
