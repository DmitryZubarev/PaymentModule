using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.Abstract.Data.Reporting
{
    public class PaymentFilter
    {
        public int ClientId { get; set; }
        public int Sum { get; set; }
        public DateTime Date { get; set; }
    }
}
