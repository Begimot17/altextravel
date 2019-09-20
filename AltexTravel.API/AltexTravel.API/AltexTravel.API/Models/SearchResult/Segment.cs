﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.SearchResult
{
    public class Segment
    {
        public string ElapseFlyingTime { get; set; }
        public List<Flight> Flights { get; set; }
    }
}
