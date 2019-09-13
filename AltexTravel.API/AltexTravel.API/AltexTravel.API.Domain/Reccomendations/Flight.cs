using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Domain.Reccomendations
{
    public class Flight
    {
        public DateTime ArrivalTime { get; set; }

        public Cabins Cabin { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public string FareBasis { get; set; }
        public string FlightNumber { get; set; }
        public string FlyingTime { get; set; }
        public string FreeBaggage { get; set; }
        public string Layover { get; set; }
        public Airline MarketingCarrier { get; set; }
        public Airline OperatingCarrier { get; set; }
        public AirportPair Route { get; set; }
        public string Rules { get; set; }
    }
}
