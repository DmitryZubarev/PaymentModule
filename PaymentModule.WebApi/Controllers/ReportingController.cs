using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentModule.Abstract.Data.Reporting;

namespace PaymentModule.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private readonly IReportingService _reportingService;

        public ReportingController(IReportingService reportingService) 
        {
            _reportingService = reportingService;
        }

        [HttpPost("[action]")]
        //[ProducesResponseType(typeof(List<Payment>)), 200]
        public async Task<IActionResult> GetPayments(
            DateTime start,
            DateTime end,
            int userCode,
            int sum)
        {
            //if smth return BadRequest();
            return Ok();
        }

        [HttpPost("[action]")]
        //[ProducesResponseType(typeof(List<Session>)), 200]
        public async Task<IActionResult> GetSessions(
            DateTime start,
            DateTime end,
            int clientCode,
            int sum,
            int tariffId)
        {
            //заменить тариф Ид на тариф

            //if smth return BadRequest();
            return Ok();
        }
    }
}
