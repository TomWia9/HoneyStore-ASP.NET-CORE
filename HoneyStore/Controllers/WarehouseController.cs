using HoneyStore.Dto;
using HoneyStore.Models;
using HoneyStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HoneyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseService warehouseService;

        public WarehouseController(HoneyStoreContext context)
        {
            warehouseService = new WarehouseService(context);
        }

        [HttpPost("AddHoney")]
        public ActionResult AddHoney(HoneyItemDto honey)
        {
            return warehouseService.AddHoney(honey);
        }

        [HttpDelete("RemoveHoney/{honeyId}")]
        public ActionResult RemoveHoney(int honeyId)
        {
            return warehouseService.RemoveHoney(honeyId);
        }

        [HttpGet("GetAllHoneys")]
        public ActionResult<IEnumerable<HoneyInTheWarehouse>> GetAllHoneys()
        {
            return warehouseService.GetAllHoneys();
        }

        [HttpGet("GetHoney/{honeyId}")]
        public ActionResult<HoneyItemDto> GetHoney(int honeyId)
        {
            return warehouseService.GetHoney(honeyId);
        }
    }
}
