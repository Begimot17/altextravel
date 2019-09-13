using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Domain.Reccomendations
{
    public class PriceDetails
    {
        public decimal BaseFare { get; set; }
        public List<decimal> Fees { get; set; }
        public decimal Taxes { get; set; }
        public int NumberOfPassengers { get; set; }
        public readonly decimal total;
    }
}
