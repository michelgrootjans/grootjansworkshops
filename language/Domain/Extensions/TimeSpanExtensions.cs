/*
 * Created by: 
 * Created: zaterdag 31 januari 2009
 */

using System;

namespace Domain.Extensions
{
    public static class TimeSpanExtensions
    {
        public static DateTime Ago(this TimeSpan time)
        {
            return DateTime.Now - time;
        }

        public static DateTime FromNow(this TimeSpan time)
        {
            return DateTime.Now + time;
        }

        public static DateTime Today(this TimeSpan time)
        {
            return DateTime.Now.Date + time;
        }

        public static DateTime Tomorrow(this TimeSpan time)
        {
            return time.Today().AddDays(1);
        }
    }
}