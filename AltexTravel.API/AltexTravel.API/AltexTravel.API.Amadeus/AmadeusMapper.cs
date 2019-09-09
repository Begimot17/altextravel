﻿using AltexTravel.API.Amadeus.Models;
using AltexTravel.API.DAL.Features.IataCodes;
using AltexTravel.API.DAL.Features.Locations;
using System.Collections.Generic;
using System.Linq;

namespace AltexTravel.API.Amadeus
{
    public static class AmadeusMapper
    {
        public static List<IataCodeDal> ToIataCode(this IEnumerable<IataAmadeus> locations)
        {
            return locations.Select(x => x.ToIataCode()).ToList();
        }
        public static List<LocationDal> ToLocations(this IEnumerable<LocationAmadeus> locations)
        {
            return locations.Select(x => x.ToLocation()).ToList();
        }
        public static List<IataAmadeus> ToIataAmadeus(this IEnumerable<LocationAmadeus> locations)
        {
            return locations.Select(x => x.ToIataAmadeus()).ToList();
        }
        public static IataAmadeus ToIataAmadeus(this LocationAmadeus model)
        {
            return (model != null) ?
               new IataAmadeus
               {
                   Name = model.Name,
                   Code = model.Code,
               } :
           new IataAmadeus();
        }
        public static IataCodeDal ToIataCode(this IataAmadeus model)
        {
            return (model != null) ?
               new IataCodeDal
               {
                   Name = model.Name,
                   Code = model.Code,
               } :
           new IataCodeDal();
        }
        public static LocationDal ToLocation(this LocationAmadeus model)
        {
            return (model.Airports != null) ?
               new LocationDal
               {
                   Name = model.Name,
                   Code = model.Code,
                   Type = model.Type,
                   Airports = model.Airports.ToIataCode()
               } :
           new LocationDal
           {
               Name = model.Name,
               Code = model.Code,
               Type = model.Type,
               Airports = null
           };
        }

    }
}
