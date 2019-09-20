using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AltexTravel.API.Amadeus.Models
{
    public class LocationAmadeus
    {
        [JsonProperty("subType")]
        public string Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("iataCode")]
        public string Code { get; set; }
        [JsonProperty("address")]
        public AddressModel Address { get; set; }
        public List<IataAmadeus> Airports { get; set; }
    }
    public class ComparerLocationAmadeus : IEqualityComparer<LocationAmadeus>
    {
        public bool Equals(LocationAmadeus x, LocationAmadeus y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;
            return x.Type.Equals(y.Type)
                || x.Name.Equals(y.Name)
                || x.Address.Country.Equals(y.Address.Country)
                || x.Address.Code.Equals(y.Address.Code);
        }

        public int GetHashCode(LocationAmadeus location)
        {
            return location.Type.GetHashCode()
                * location.Name.GetHashCode()
                * location.Address.Country.GetHashCode()
                * location.Address.Code.GetHashCode();
        }
    }
}
