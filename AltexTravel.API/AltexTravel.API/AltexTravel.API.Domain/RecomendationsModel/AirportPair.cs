using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Domain.RecomendationsModel
{
    public class AirportPair
    {
        public Airport ArrivalPort { get; set; }
        public Airport DeparturePort { get; set; }
    }
}
