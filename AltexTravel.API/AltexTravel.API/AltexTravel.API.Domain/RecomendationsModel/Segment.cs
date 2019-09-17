using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Domain.RecomendationsModel
{
    public class Segment
    {
        public string ElapseFlyingTime { get; set; }
        public List<Flight> Flights { get; set; }
    }
}
