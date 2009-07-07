using NUnit.Framework;
using WarOfWorldcraft.Utilities.Extensions;

namespace UnitTests.TestUtilities.Extensions
{
    public static class StringExtensions
    {
        public static void ShouldBeEmpty(this string target)
        {
            Assert.IsTrue(target.IsEmpty());
        }
    }
}