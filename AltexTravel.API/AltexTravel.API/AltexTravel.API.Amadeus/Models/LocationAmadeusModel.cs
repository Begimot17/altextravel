using AltexTravel.API.DAL.Features.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models
{
    public class LocationAmadeusModel
    {
        public List<LocationDal> Locations { get; set; }
    }
}
