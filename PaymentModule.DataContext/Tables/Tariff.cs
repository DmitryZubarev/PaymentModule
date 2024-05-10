using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.DataContext.Tables
{
    public class Tariff
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public Goods Goods { get; set; }
        public int Price { get; set; }
        public DateTime Time { get; set; }
    }
}
