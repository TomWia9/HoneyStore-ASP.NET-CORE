using HoneyStore.Dto;
using HoneyStore.Models;
using HoneyStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace HoneyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly StatisticsService statisticsService;

        public StatisticsController(HoneyStoreContext context)
        {
            statisticsService = new StatisticsService(context);
        }

        [HttpGet("GetNumberOfOrdersData/{peroid}")]
        public ActionResult<NumberOfOrdersDataDto> GetNumberOfOrdersData(int peroid)
        {
            return statisticsService.GetNumberOfOrdersData(peroid);
        }

        [HttpGet("GetNumberOfSpecyficOrdersData/{peroid}")]
        public ActionResult<NumberOfOrdersDataDto> GetNumberOfSpecyficOrdersData(int peroid)
        {
            return statisticsService.GetNumberOfSpecyficOrdersData(peroid);
        }


    }
}
