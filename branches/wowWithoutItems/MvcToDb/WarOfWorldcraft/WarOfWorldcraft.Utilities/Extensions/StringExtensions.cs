namespace WarOfWorldcraft.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static long ToLong(this string value)
        {
            long result;
            long.TryParse(value, out result);
            return result;
        }

        public static bool IsEmpty(this string target)
        {
            return string.Empty.Equals(target);
        }

        public static bool IsNotEmpty(this string target)
        {
            return !target.IsEmpty();
        }

        public static bool IsNullOrEmpty(this string target)
        {
            return string.IsNullOrEmpty(target);
        }

        public static bool IsNotNullOrEmpty(this string target)
        {
            return !target.IsNullOrEmpty();
        }
    }
}