using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.SearchResult
{
    public class Flight
    {

        public string ElapseFlyingTime { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }

        public string Cabin { get; set; }
        public Equipment EquipmentType { get; set; }
        public string FareBasis { get; set; }
        public int FlightNumber { get; set; }
        public TimeSpan FlyingTime { get; set; }
        public string FreeBaggage { get; set; }
        public string Layover { get; set; }
        public Airline MarketingCarrier { get; set; }
        public Airline OperatingCarrier { get; set; }
        public AirportPair Route { get; set; }
        public string Rules { get; set; }
    }
}
