using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentModule.Abstract.BusinessLogic;

namespace PaymentModule.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharingController : ControllerBase
    {
        private readonly ISharingSessionService _sharingSessionService;

        public SharingController(ISharingSessionService sharingSessionService) 
        {
            _sharingSessionService = sharingSessionService;
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
        public async Task<IActionResult> GetBankForm(
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
            Uri clientReturnUrl)
        {
            return Ok();
        }

        //
        /// <summary>
        /// брат, тормози сессию, пользователь умер
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [HttpPatch("[action]")]
        public async Task<IActionResult> StopSession(int sessionId)
        {
            return Ok();
        }
    }
}
