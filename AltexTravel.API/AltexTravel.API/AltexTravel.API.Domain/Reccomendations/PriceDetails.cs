using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Domain.Reccomendations
{
    public class PriceDetails
    {
        public double BaseFare { get; set; }
        public List<double> Fees { get; set; }
        public double Taxes { get; set; }
        public int NumberOfPassengers { get; set; }
        public readonly double total;
    }
}
