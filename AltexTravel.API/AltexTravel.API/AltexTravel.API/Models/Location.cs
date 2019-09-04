﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models
{
    public class Location
    {
        public List<IataCode> Airports { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
