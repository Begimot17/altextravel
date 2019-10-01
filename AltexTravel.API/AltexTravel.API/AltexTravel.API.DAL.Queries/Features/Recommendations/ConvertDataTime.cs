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
            return difference.TimeFormat();
        }

        public static TimeSpan FlyingTimeConvert(this Services segment)
        {
            var depTime = DateTime.Parse(segment.Segments.First().FlightSegment.Departure.At);
            var arrivTime = DateTime.Parse(segment.Segments.Last().FlightSegment.Arrival.At);
            var difference = arrivTime - depTime;
            return difference.TimeFormat();
        }
        public static TimeSpan TimeFormat(this TimeSpan time) =>
            new TimeSpan(time.Days * 24 + time.Hours, time.Minutes, time.Seconds);
    }
}
