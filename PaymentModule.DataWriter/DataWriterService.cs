using PaymentModule.Abstract.Data;
using PaymentModule.Abstract.Data.DataWriter;
using PaymentModule.DataContext;
using PaymentModule.DataContext.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.DataWriter
{
    public class DataWriterService : IDbWriterService
    {
        private readonly ApplicationContext _context;

        public DataWriterService(ApplicationContext context)
        {
            _context = context;
        }

        public void WritePayment(PaymentModel paymentModel)
        {
            Payment payment = new Payment
            {
                Id = 0,
                ClientId = paymentModel.ClientId,
                DateTime = paymentModel.DateTime,
                Sum = paymentModel.Sum,
            };
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public void WriteSharingSession(SharingSessionModel sharingSessionModel)
        {
            SharingSession session = new SharingSession
            {
                Id = 0,
                StartDateTime = sharingSessionModel.StartDateTime,
                EndDateTime = sharingSessionModel.EndDateTime,
                ClientId = sharingSessionModel.ClientId,
                Sum = sharingSessionModel.Sum,
                Tariff = _context.Tariffs.Where(x => x.Id == sharingSessionModel.TariffId).FirstOrDefault(),
            };
            _context.SharingSessions.Add(session);
            _context.SaveChanges();
        }
    }
}
