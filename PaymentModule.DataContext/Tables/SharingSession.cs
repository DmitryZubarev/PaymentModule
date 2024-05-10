using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.DataContext.Tables
{
    public class SharingSession
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int ClientId { get; set; }
        public int Sum { get; set; }
        public Tariff Tariff { get; set; }
    }
}
