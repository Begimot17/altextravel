using AltexTravel.API.DAL.Features.Locations;

namespace AltexTravel.API.DAL.Features.IataCodes
{
    public class IataCode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual Location Location { get; set; }
    }
}
