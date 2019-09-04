using AltexTravel.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.Flights.Booking
{
    public class BookingItinerary
    {
        public List<AirportCodePair> Airports { get; set; }
        public SearchRequestType SearchRequestType { get; set; }
    }
}
