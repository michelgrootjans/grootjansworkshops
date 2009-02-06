/*
 * Created by: 
 * Created: zaterdag 31 januari 2009
 */

namespace Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string subject)
        {
            return string.IsNullOrEmpty(subject);
        }
    }
}