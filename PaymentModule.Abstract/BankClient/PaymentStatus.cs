using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.Abstract.BankClient
{
    public class PaymentStatus
    {
        public bool OrderStatus {  get; set; }
        public int BindingId { get; set; }
    }
}
