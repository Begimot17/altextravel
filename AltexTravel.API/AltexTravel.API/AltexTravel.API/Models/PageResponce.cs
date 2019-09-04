using AltexTravel.API.Models.TravelAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models
{
    public class PageResponce
    {
        public int Count { get; set; }
        public Booking Items { get; set; }
    }
}
