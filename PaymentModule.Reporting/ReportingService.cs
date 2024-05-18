using PaymentModule.Abstract.Data;
using PaymentModule.Abstract.Data.Reporting;
using PaymentModule.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.Reporting
{
    public class ReportingService : IReportingService
    {
        private readonly ApplicationContext _context;

        public ReportingService(ApplicationContext context)
        {
            _context = context;
        }

        public List<PaymentModel> GetPaymentsData(PaymentFilter paymentFilter)
        {
            var data = _context.Payments;
            var payments = data.Select(x => x);

            if (paymentFilter.Date != null)
            {
                payments = payments.Where(x => x.DateTime == paymentFilter.Date);
            }
            if (paymentFilter.Sum != null)
            {
                payments = payments.Where(x => x.Sum == paymentFilter.Sum);
            }
            if (paymentFilter.ClientId != null)
            {
                payments = payments.Where(x => x.ClientId == paymentFilter.ClientId);
            }

            var result = payments.Select(x => new PaymentModel
            {
                Id = x.Id,
                DateTime = x.DateTime,
                ClientId = x.ClientId,
                Sum = x.Sum,
            }).ToList();

            return result;
        }

        public List<SharingSessionModel> GetSharingSessionsData(SharingSessionFilter sessionFilter)
        {
            var data = _context.SharingSessions;
            var sessions = data.Select(x => x);

            if (sessionFilter.ClientId != null)
            {
                sessions = sessions.Where(x => x.ClientId == sessionFilter.ClientId);
            }
            if (sessionFilter.StartDateTime != null)
            {
                sessions = sessions.Where(x => x.StartDateTime == sessionFilter.StartDateTime);
            }
            if (sessionFilter.EndDateTime != null)
            {
                sessions = sessions.Where(x => x.EndDateTime == sessionFilter.EndDateTime);
            }
            if (sessionFilter.Sum != null)
            {
                sessions = sessions.Where(x => x.Sum == sessionFilter.Sum);
            }
            if (sessionFilter.TariffId != null)
            {
                var tariff = _context.Tariffs.Where(x => x.Id == sessionFilter.TariffId).FirstOrDefault();
                sessions = sessions.Where(x => x.Tariff == tariff);
            }

            var result = sessions.Select(x => new SharingSessionModel
            {
                Id = x.Id,
                ClientId = x.ClientId,
                StartDateTime = x.StartDateTime,
                EndDateTime = x.EndDateTime,
                Sum = x.Sum,
                TariffId = x.Tariff.Id,
            }).ToList();

            return result;
        }
    }
}
