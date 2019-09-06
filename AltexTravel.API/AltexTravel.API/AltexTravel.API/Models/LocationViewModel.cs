﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AltexTravel.API.Models
{
    public class LocationViewModel
    {
        public string Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IEnumerable<IataCodeViewModel> Airports { get; set; }
    }
}
