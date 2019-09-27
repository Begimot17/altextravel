using AltexTravel.API.Amadeus.Models.SearchResult;
using System;
using System.Linq;

namespace AltexTravel.API.DAL.Queries.Features.Recommendations
{
    public static class ConvertDataTime
    {
        public static TimeSpan DifferenceTime(string firstTime, string lastTime)
        {
            var firstDate = DateTime.Parse(firstTime);
            var lastDate = DateTime.Parse(lastTime);
            var difference = lastDate - firstDate;
            return difference;
        }

        public static TimeSpan FlyingTimeConvert(this Services segment)
        {
            var depTime = DateTime.Parse(segment.Segments.First().FlightSegment.Departure.At);
            var arrivTime = DateTime.Parse(segment.Segments.Last().FlightSegment.Arrival.At);
            return arrivTime - depTime;
        }
    }
}
