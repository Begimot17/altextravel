using AltexTravel.API.DAL.Features.Locations;
using System;
using System.Collections.Generic;

namespace AltexTravel.API.DAL.Features.IataCodes
{
    public class IataCode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }

        public virtual Location Location { get; set; }
    }
    public class ComparerIata : IEqualityComparer<IataCode>
    {
        public bool Equals(IataCode x, IataCode y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;
            return x.Code.Equals(y.Code) || x.Name.Equals(y.Name) || x.Country.Equals(y.Country);
        }

        public int GetHashCode(IataCode routeRel)
        {
            return routeRel.Code.GetHashCode() * routeRel.Name.GetHashCode() * routeRel.Country.GetHashCode();
        }
    }
}
