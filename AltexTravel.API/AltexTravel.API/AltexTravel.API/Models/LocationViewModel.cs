using System.Collections.Generic;

namespace AltexTravel.API.Models
{
    public class LocationViewModel
    {
        public string Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public IEnumerable<IataCodeViewModel> Airports { get; set; }
    }
}
