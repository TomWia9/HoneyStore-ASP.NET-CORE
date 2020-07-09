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
        public ActionResult AddToCart(HoneyInTheCartDto honey, int clientId)
        {
            return cartsService.AddToCart(honey, clientId);
        }

        [HttpGet("GetCart/{clientId}")]
        public ActionResult<CartDto> GetCart(int clientId)
        {
            return cartsService.GetCart(clientId);
        }

        [HttpPatch("UpdateCart/{clientId}")]
        public ActionResult UpdateCart(HoneyInTheCartDto honey, int clientId)
        {
            return cartsService.UpdateCart(honey, clientId);
        }

        [HttpDelete("RemoveItemFromCart/{honeyName}/{clientId}")]
        public ActionResult RemoveItemFromCart(string honeyName, int clientId)
        {
            return cartsService.RemoveItemFromCart(honeyName, clientId);
        }

        [HttpGet("IsEmpty/{clientId}")]
        public ActionResult<bool> IsEmpty(int clientId)
        {
            return cartsService.IsEmpty(clientId);
        }
    }
}
