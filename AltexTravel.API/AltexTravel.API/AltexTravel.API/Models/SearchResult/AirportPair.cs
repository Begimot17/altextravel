﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.SearchResult
{
    public class AirportPair
    {
        public Airport ArrivalPort { get; set; }
        public Airport DeparturePort { get; set; }
    }
}
