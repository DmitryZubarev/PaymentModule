using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.Abstract.BankClient
{
    public class OrderRegisterResponse
    {
        public int OrderId { get; set; }
        public Uri BankFormUrl { get; set; }
    }
}
