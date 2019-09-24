using System;
using System.Collections.Generic;
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
            var timeSplit = time.Split('D', 'T', 'H', 'M');
            var timeList = timeSplit.Where(x => x != "").Select(x => Int32.Parse(x)).ToList();
            if (timeList[0] != 0)
            {
                timeList[1] += timeList[0] * 24;
            }
            return $"{timeList[1].DoubleInt()}:{timeList[2].DoubleInt()}:00";
        }
        public static string DoubleInt(this int x) =>
             x < 10 && x > 0 ? $"0{x}" : $"{x}";
    }
}
