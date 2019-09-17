using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Domain.RecomendationsModel
{
    public class Recommendation
    {
        public string CachedFlightReference { get; set; }
        public List<Segment> Segments { get; set; }
        public PriceInfo PriceDetails { get; set; }
    }
}
