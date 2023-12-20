using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Extensions
{
    public static class TimeSpanExtensions
    {
        public static bool IsBetween(this TimeSpan timeToCheck, TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime <= endTime)
                return timeToCheck >= startTime && timeToCheck <= endTime;
            else
                return timeToCheck >= startTime || timeToCheck <= endTime;
        }

        public static TimeSpan AddMinutes(this TimeSpan originalTimeSpan, int minutes)
        {
            return originalTimeSpan.Add(TimeSpan.FromMinutes(minutes));
        }
    }
}
