﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Domain.Reccomendations
{
    public class Airport
    {
        public City City { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
