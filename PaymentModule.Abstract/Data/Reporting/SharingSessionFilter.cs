using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.Abstract.Data.Reporting
{
    public class SharingSessionFilter
    {
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? ClientId { get; set; }
        public int? Sum { get; set; }
        public int? TariffId { get; set; }
    }
}
