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
    }
}