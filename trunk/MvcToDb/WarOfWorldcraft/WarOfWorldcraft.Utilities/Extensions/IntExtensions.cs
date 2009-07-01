namespace WarOfWorldcraft.Utilities.Extensions
{
    public static class IntExtensions
    {
        public static int Minimum(this int value, int minimum)
        {
            return value > minimum
                       ? value
                       : minimum;
        }
    }
}