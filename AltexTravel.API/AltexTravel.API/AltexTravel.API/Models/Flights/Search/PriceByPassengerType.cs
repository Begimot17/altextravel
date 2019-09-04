using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.Flights.Search
{
    public class PriceByPassengerType
    {
        public PriceDetails Adult { get; set; }
        public PriceDetails Child { get; set; }
        public PriceDetails Infant { get; set; }
    }
}
