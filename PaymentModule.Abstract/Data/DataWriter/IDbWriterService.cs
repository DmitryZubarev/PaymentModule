using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.Abstract.Data.DataWriter
{
    public interface IDbWriterService
    {
        public void WritePayment(PaymentModel payment);
        public void WriteSharingSession(SharingSessionModel sharingSession);
    }
}
