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

        public static string FlyingTimeConvert(this string time)
        {
            var flyingTime = TimeSpan.ParseExact(time, @"d\D\Th\Hm\M", CultureInfo.CurrentCulture);
            return string.Format("{0:00}:{1:00}:00", (flyingTime.Days * 24) + flyingTime.Hours, flyingTime.Minutes);
        }

        public static string DoubleInt(this int x) =>
             x < 10 && x >= 0 ? $"0{x}" : $"{x}";
    }
}
