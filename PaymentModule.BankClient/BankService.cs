using PaymentModule.Abstract.BankClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.BankClient
{
    public class BankService : IBankService
    {
        public void DoAutoPayment(int shopOrderId, int bindingId)
        {
            throw new NotImplementedException();
        }

        public bool GetAutoPaymentOrderStatus(int bankOrderId)
        {
            throw new NotImplementedException();
        }

        public PaymentStatus GetFirstPaymentOrderStatus(int orderId)
        {
            throw new NotImplementedException();
        }

        public int StartAutoPayment(int clientId, int shopOrderId, int sum, Uri returnShopWindow)
        {
            throw new NotImplementedException();
        }

        public OrderRegisterResponse StartFirstPayment(int clientId, int shopOrderId, int sum, Uri returnShopWindow)
        {
            throw new NotImplementedException();
        }
    }
}
