using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.SearchResult
{
    public class PriceDetails
    {
        public decimal BaseFare { get; set; }
        public List<decimal> Fees { get; set; }
        public decimal Taxes { get; set; }
        public int NumberOfPassengers { get; set; }
        public decimal Total { get; set; }
    }
}
