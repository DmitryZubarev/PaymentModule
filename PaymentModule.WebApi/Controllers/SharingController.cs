using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentModule.Abstract.BusinessLogic;
using PaymentModule.Core.Services;

namespace PaymentModule.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharingController : ControllerBase
    {
        private readonly ISharingSessionService _sessionService;

        public SharingController(ISharingSessionService sharingSessionService) 
        {
            _sessionService = sharingSessionService;
        }

        //
        /// <summary>
        /// ядро говорит, что тело хочет провести первый платёж
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="tariffId"></param>
        /// <param name="orderNumber"></param>
        /// <param name="clientReturnUrl"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> StartFirstPayment(
            int clientId,
            int tariffId,
            int orderNumber,
            Uri clientReturnUrl)
        {
            return Ok();
        }

        //
        /// <summary>
        /// ядро говорит, что тело попробовало оплатить первый платёж
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpPatch("[action]")]
        public async Task<IActionResult> CheckFirstPaymentStatus(int clientId)
        {
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> StartAutoPayment(
            int clientId,
            int tariffId,
            int orderNumber,
            Uri clientReturnUrl,
            int bindingId)
        {
            
            _sessionService.StartAutoPayment(clientId, orderNumber, tariffId, clientReturnUrl, bindingId);
            return Ok();
        }

        //
        /// <summary>
        /// брат, тормози сессию, пользователь умер
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [HttpPatch("[action]")]
        public async Task<IActionResult> StopSession(int orderNumber)
        {
            _sessionService.EndSession(orderNumber);
            return Ok();
        }
    }
}
