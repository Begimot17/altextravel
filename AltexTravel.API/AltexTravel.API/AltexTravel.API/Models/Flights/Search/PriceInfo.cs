using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.Flights.Search
{
    public class PriceInfo
    {
        public string DataSource { get; set; }
        public PriceByPassengerType PriceByPassengerType { get; set; }
        public double total { get; set; }
    }
}
