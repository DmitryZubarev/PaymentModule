using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentModule.Abstract.Data;
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
        //[ProducesResponseType(typeof(List<PaymentModel>)), 200]
        public async Task<IActionResult> GetPayments(PaymentFilter filter)
        {
            var result = _reportingService.GetPaymentsData(filter);
            //if smth return BadRequest();
            return Ok(result);
        }

        [HttpPost("[action]")]
        //[ProducesResponseType(typeof(List<SharingSessionModel>)), 200]
        public async Task<IActionResult> GetSessions(SharingSessionFilter filter)
        {
            var result = _reportingService.GetSharingSessionsData(filter);
            //заменить тариф Ид на тариф

            //if smth return BadRequest();
            return Ok(result);
        }
    }
}
