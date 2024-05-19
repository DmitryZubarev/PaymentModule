using PaymentModule.Abstract.BankClient;
using PaymentModule.Abstract.BusinessLogic;
using PaymentModule.Abstract.Data;
using PaymentModule.Abstract.Data.DataWriter;
using PaymentModule.Core.Models.Entities;
using PaymentModule.DataContext;
using PaymentModule.DataContext.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.Core.Services
{
    public class ActiveSessionService : ISharingSessionService
    {
        private IDbWriterService _dbWriterService;
        private IBankService _bankService;
        private ApplicationContext _context;

        public List<ActiveSession> ActiveSessions { get; set; } = new List<ActiveSession>();

        public ActiveSessionService(
            IDbWriterService writerService,
            IBankService bankService,
            ApplicationContext context) 
        {
            _dbWriterService = writerService;
            _bankService = bankService;
            _context = context;
        }

        public void StartAutoPayment(int clientId, int shopOrderId, int tariffId, Uri returnShopWindow, int bindingId)
        {
            var session = new ActiveSession()
            {
                ClientId = clientId,
                Tariff = _context.Tariffs.Where(x => x.Id == tariffId).FirstOrDefault(),
                Sum = 0,
                StartDateTime = DateTime.Now,
                ShopOrderId = shopOrderId,
                BindingId = bindingId,
            };
            TimerCallback callback = new TimerCallback(DoPayment);
            session.Timer = new Timer(callback, session, 0, (int)session.Tariff.Time.TotalMilliseconds);
            ActiveSessions.Add(session);
        }

        public void EndSession(int shopOrderId)
        {
            var stopedSession = ActiveSessions.Where(x => x.ShopOrderId == shopOrderId).FirstOrDefault();
            stopedSession.Timer.Dispose();
            var session = new SharingSession()
            {
                EndDateTime = DateTime.Now,
                StartDateTime = stopedSession.StartDateTime,
                ClientId = stopedSession.ClientId,
                Sum = stopedSession.Sum,
                Tariff = stopedSession.Tariff,
                ShopOrderId = shopOrderId,
            };
            _context.SharingSessions.Add(session);
            _context.SaveChanges();
        }

        private void DoPayment(object obj)
        {
            var session = obj as ActiveSession;
            Payment payment = new Payment();
            payment.ClientId = session.ClientId;
            payment.DateTime = DateTime.Now;
            payment.Sum = session.Tariff.Price;
            session.Sum += session.Tariff.Price;
            _context.Payments.Add(payment);
            _context.SaveChanges();

            Console.WriteLine($@"
Время - {payment.DateTime}
Платёж должен был быть)");
        }

        public OrderRegisterResponse StartFirstPayment(int clientId, int shopOrderId, int sum, Uri returnShopWindow)
        {
            throw new NotImplementedException();
        }

        public PaymentStatus GetFirstPaymentOrderStatus(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
