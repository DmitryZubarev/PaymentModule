using PaymentModule.DataContext.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.Core.Models.Entities
{
    public class ActiveSession
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int ClientId { get; set; }
        public int Sum { get; set; }
        public Tariff Tariff { get; set; }
        public Timer Timer { get; set; }
        public int ShopOrderId { get; set; }
        public int BindingId { get; set; }
    }
}
