using AltexTravel.API.DAL.Features.IataCodes;
using System.Collections.Generic;
namespace AltexTravel.API.DAL.Features.Locations
{
    public class LocationDal
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual List<IataCodeDal> Airports { get; set; }
    }
}
