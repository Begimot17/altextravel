﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.Flights.Search
{
    public class Recommendation
    {
        public string CachedFlightReference { get; set; }
        public List<Segment> Segments { get; set; }
        public PriceInfo PriceDetails { get; set; }
    }
}
