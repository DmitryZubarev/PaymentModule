using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.Abstract.Data.Reporting
{
    public interface IReportingService
    {
        public List<PaymentModel> GetPaymentsData(PaymentFilter paymentFilter);
        public List<SharingSessionModel> GetSharingSessionsData(SharingSessionFilter sessionFilter);
    }
}
