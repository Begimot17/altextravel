using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.Flights.Search
{
    public class RequestSegment
    {
        public DateTime DepartureDate { get; set; }
        public AirportCodePair Route { get; set; }
    }
}
