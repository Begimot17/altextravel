using System;
using System.Collections.Generic;

namespace AltexTravel.API.Amadeus.Models
{
    public class IataAmadeus
    { 
        public string Name { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }

    }
    public class RouteRelComparerIataAmadeus : IEqualityComparer<IataAmadeus>
    {
        public bool Equals(IataAmadeus x, IataAmadeus y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;
            return x.Code.Equals(y.Code) || x.Name.Equals(y.Name) || x.Country.Equals(y.Country);
        }

        public int GetHashCode(IataAmadeus routeRel)
        {
            return routeRel.Code.GetHashCode() * routeRel.Name.GetHashCode() * routeRel.Country.GetHashCode();
        }
    }
}
