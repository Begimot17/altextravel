using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Domain
{
    public class Location
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IEnumerable<IataCode> Airports { get; set; }
        
    }
}
