/*
 * Created by: 
 * Created: zaterdag 31 januari 2009
 */

using System;

namespace Domain.Extensions
{
    public static class IntExtensions
    {
        public static TimeSpan Hours(this int time)
        {
            return TimeSpan.FromHours(time);
        }

        public static TimeSpan Minutes(this int time)
        {
            return TimeSpan.FromMinutes(time);
        }
    }
}