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
        public int LocationId { get; set; }
        public int GoodsId { get; set; }
        public virtual Location Location { get; set; }
        public virtual Goods Goods { get; set; }
        public int Price { get; set; }
        public TimeSpan Time { get; set; }
    }
}
