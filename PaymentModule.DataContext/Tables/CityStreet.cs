using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.DataContext.Tables
{
    public class CityStreet
    {
        public int Id { get; set; }
        public City City { get; set; }
        public Street Street { get; set; }
    }
}
