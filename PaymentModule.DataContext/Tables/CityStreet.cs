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
        public int CityId { get; set; } 
        public int StreetId { get; set; }
        public virtual City City { get; set; }
        public virtual Street Street { get; set; }
    }
}
