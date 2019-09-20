using AltexTravel.API.DAL.Features.IataCodes;
using System;
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
    public class RouteRelComparerLocal : IEqualityComparer<Location>
    {
        public bool Equals(Location x, Location y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;
            return x.Code.Equals(y.Code) || x.Name.Equals(y.Name) || x.Type.Equals(y.Type);
        }

        public int GetHashCode(Location location)
        {
            return location.Code.GetHashCode()* location.Name.GetHashCode()* location.Type.GetHashCode();
        }
    }
}
