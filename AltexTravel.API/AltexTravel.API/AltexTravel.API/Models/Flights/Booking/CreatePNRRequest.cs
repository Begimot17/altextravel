using AltexTravel.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.Flights.Booking
{
    public class CreatePNRRequest
    {
        public string CachedFlightReference { get; set; }
        public DataSource DataSource { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public List<Passenger> Passengers { get; set; }
    }
}
