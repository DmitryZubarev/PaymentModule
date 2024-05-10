using PaymentModule.Abstract.BankClient;
using PaymentModule.Abstract.BusinessLogic;
using PaymentModule.Abstract.Data.DataWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.Core.Services
{
    public class SharingSessionService : ISharingSessionService
    {
        private readonly IDbWriterService _dbWriterService;
        private readonly IBankService _bankService;


        public SharingSessionService(
            IDbWriterService dbWriterService,
            IBankService bankService)
        {
            _dbWriterService = dbWriterService;
            _bankService = bankService;
        }

        
        //Выполнить при попытке оплаты новым клиентом или старым клиентом, если он хочет оплатить другой картой
        public OrderRegisterResponse StartFirstPayment(int clientId, int shopOrderId, int sum, Uri returnShopWindow)
        {
            throw new NotImplementedException();
        }

        //Выполнить, когда клиента вернуло на сайт магазина после оплаты
        public PaymentStatus GetFirstPaymentOrderStatus(int orderId)
        {
            throw new NotImplementedException();
        }

        //Для старта сессии старого клиента с оплатой его последней карты
        public bool StartAutoPayment(int clientId, int shopOrderId, int sum, Uri returnShopWindow, int bindingId)
        {
            throw new NotImplementedException();
        } 
    }
}
