﻿using AltexTravel.API.Amadeus.Models.SearchResult;
using AltexTravel.API.Domain.RecomendationsModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

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

        //public static string FlyingTimeConvert(this string time)
        //{
        //    var flyingTime = TimeSpan.ParseExact(time, @"d\D\Th\Hm\M", CultureInfo.CurrentCulture);
        //    return string.Format("{0:00}:{1:00}:00", (flyingTime.Days * 24) + flyingTime.Hours, flyingTime.Minutes);
        //}
        public static TimeSpan FlyingTimeConvert(this Services segment)
        {
            var timeDep = segment.Segments[0].FlightSegment.Departure.At;
            var depTime = DateTime.Parse(timeDep);

            var timeArriv = segment.Segments[segment.Segments.Count - 1].FlightSegment.Arrival.At;
            var arrivTime = DateTime.Parse(timeArriv);
            return arrivTime - depTime;
        }
    }
}
