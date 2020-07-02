using HoneyStore.Dto;
using HoneyStore.Models;
using HoneyStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace HoneyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly CartsService cartsService;

        public CartsController(HoneyStoreContext context)
        {
            cartsService = new CartsService(context);
        }

        [HttpPost("AddToCart/{clientId}")]
        public ActionResult AddToCart(HoneyItemDto honey, int clientId)
        {
            return cartsService.AddToCart(honey, clientId);
        }

        [HttpGet("GetCart/{clientId}")]
        public ActionResult<CartDto> GetCart(int clientId)
        {
            return cartsService.GetCart(clientId);
        }
    }
}
