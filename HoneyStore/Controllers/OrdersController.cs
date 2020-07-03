using HoneyStore.Dto;
using HoneyStore.Models;
using HoneyStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HoneyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersService ordersService;

        public OrdersController(HoneyStoreContext context)
        {
            ordersService = new OrdersService(context);
        }

        [HttpGet("GetOrder/{orderId}")]
        public ActionResult<OrderDto> GetOrder(int orderId)
        {
            return ordersService.GetOrder(orderId);
        }

        [HttpGet("GetOrders/{all}")]
        public ActionResult<IEnumerable<OrderDto>> GetOrders(Status status, bool all)
        {
            return ordersService.GetOrders(status, all);
        }

        [HttpPost("NewOrder")]
        public ActionResult NewOrder(OrderDto order)
        {
            return ordersService.NewOrder(order);
        }

        [HttpPatch("SendTheOrder/{orderId}")]
        public ActionResult SendTheOrder(int orderId)
        {
            return ordersService.SendTheOrder(orderId);
        }

        [HttpPatch("ConfirmDelivery/{orderId}")]
        public ActionResult ConfirmDelivrey(int orderId)
        {
            return ordersService.ConfirmDelivery(orderId);
        }

        [HttpDelete("CancelTheOrder/{orderId}")]
        public ActionResult CancelTheOrder(int orderId)
        {
            return ordersService.CancelTheOrder(orderId);
        }

    }
}
