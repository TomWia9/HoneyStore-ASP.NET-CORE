﻿using HoneyStore.Dto;
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

        [HttpGet("GetOrders/{all}/{status}")]
        public ActionResult<IEnumerable<OrderDto>> GetOrders(bool all, Status status)
        {
            return ordersService.GetOrders(all, status);
        }

        [HttpGet("GetClientOrders/{clientId}/{status}")]
        public ActionResult<IEnumerable<OrderDto>> GetClientOrders(int clientId, Status status)
        {
            return ordersService.GetClientOrders(clientId, status);
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
