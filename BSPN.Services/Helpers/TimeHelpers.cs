using System;

namespace BSPN.Services
{
    public class TimeHelpers
    {
        public static DateTime GetCurrentCentralTime()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
        }
    }
}