using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.DataContext.Tables
{
    public class Location
    {
        public int Id { get; set; }
        public CityStreet CityStreet { get; set; }
        public int BuildingNumber { get; set; }
        public string BuildingSubNumber { get; set; } = string.Empty;
    }
}
