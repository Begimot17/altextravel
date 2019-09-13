using System.Collections.Generic;

namespace AltexTravel.API.Domain
{
    public class Location
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public IEnumerable<IataCode> Airports { get; set; }

    }
}
