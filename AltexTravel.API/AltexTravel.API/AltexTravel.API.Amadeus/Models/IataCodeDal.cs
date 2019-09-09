using AltexTravel.API.DAL.Features.Locations;

namespace AltexTravel.API.DAL.Features.IataCodes
{
    public class IataCodeDal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual LocationDal Location { get; set; }
    }
}
