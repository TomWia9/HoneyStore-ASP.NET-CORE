using HoneyStore.Models;
using HoneyStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<int>> GetNumberOfOrdersData(int peroid)
        {
            return statisticsService.GetNumberOfOrdersData(peroid);
        }

        [HttpGet("GetNumberOfOrdersDataLabels/{peroid}")]
        public ActionResult<IEnumerable<string>> GetNumberOfOrdersDataLabels(int peroid)
        {
            return statisticsService.GetNumberOfOrdersDataLabels(peroid);
        }

        [HttpGet("GetNumberOfSpecyfiOrdersData/{peroid}")]
        public ActionResult<IEnumerable<int>> GetNumberOfSpecyfiOrdersData(int peroid)
        {
            return statisticsService.GetNumberOfSpecyfiOrdersData(peroid);
        }

        [HttpGet("GetNumberOfSpecifyOrdersDataLabels")]
        public ActionResult<IEnumerable<string>> GetNumberOfSpecifyOrdersDataLabels()
        {
            return statisticsService.GetNumberOfSpecifyOrdersDataLabels();
        }
    }
}
