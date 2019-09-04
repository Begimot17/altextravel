using AltexTravel.API.Enums;
using AltexTravel.API.Models.Flights.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.TravelAgent
{
    public class Booking
    {
        public int Id { get; set; }
        public List<string> BookingReferences { get; set; }
        public DateTime DepartureDate { get; set; }
        public double Price { get; set; }
        public DateTime BookingDate { get; set; }
        public string DataSource { get; set; }
        public BookingItinerary Itinerary { get; set; }
        public Status Status { get; set; }
        public Travellers Travellers { get; set; }

    }
}
