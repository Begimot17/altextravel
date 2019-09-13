using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.SearchResult
{
    public class PriceInfo
    {
        public string DataSource { get; set; }
        public PriceByPassengerType PriceByPassengerType { get; set; }
        public decimal total { get; set; }
    }
}
