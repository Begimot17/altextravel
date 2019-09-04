using AltexTravel.API.Enums;
using AltexTravel.API.Models.Flights.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.Flights.Booking
{
    public class BookingDetails
    {
        public int Id { get; set; }
        public Customer ContactPerson { get; set; }
        public string GlobalDistributionSystem { get; set; }
        public string BookingReference { get; set; }
        public List<Passenger> Passengers { get; set; }
        public PriceInfo PriceDetails { get; set; }
        public List<Segment> Segments { get; set; }
        public DateTime BookingDate { get; set; }
        public string DataSource { get; set; }
        public BookingItinerary Itinerary { get; set; }
        public Status Status { get; set; }
        public Travellers Travellers { get; set; }
    }
}
