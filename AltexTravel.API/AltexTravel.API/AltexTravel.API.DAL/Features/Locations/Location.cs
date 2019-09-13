using AltexTravel.API.DAL.Features.IataCodes;
using System.Collections.Generic;
namespace AltexTravel.API.DAL.Features.Locations
{
    public class Location
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual List<IataCode> Airports { get; set; }
    }
}
