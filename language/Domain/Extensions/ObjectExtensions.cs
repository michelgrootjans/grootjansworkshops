/*
 * Created by: 
 * Created: zaterdag 31 januari 2009
 */

namespace Domain.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNotNull(this object subject)
        {
            return subject != null;
        }

        public static bool IsNull(this object subject)
        {
            return subject == null;
        }
    }
}