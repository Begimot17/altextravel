using System.Collections.Generic;

namespace AltexTravel.API.Models
{
    public class LocationViewModel
    {
        public List<IataCodeViewModel> Airports { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
