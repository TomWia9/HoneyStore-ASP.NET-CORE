using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyStore.Dto;
using HoneyStore.Models;
using HoneyStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoneyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsService clientsService;

        public ClientsController(HoneyStoreContext context)
        {
            clientsService = new ClientsService(context);
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDto register)
        {
            return clientsService.Register(register);
        }

        [HttpGet("GetClients")]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            return clientsService.GetClients();
        }
    }
}
