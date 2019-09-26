using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.DAL.Queries.Features.Recommendations
{
    public class FiltrationParams
    {
        public List<NumberOfStops> NumberOfStops { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }
        public List<string> Airlines { get; set; }
        public List<string> Arrival { get; set; }
        public List<string> Departure { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
