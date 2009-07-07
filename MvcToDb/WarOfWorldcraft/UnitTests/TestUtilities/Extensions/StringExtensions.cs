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

        public static void ShouldContain(this string target, string expected)
        {
            Assert.IsTrue(target.Contains(expected), string.Format("Expected '{0}' in string '{1}'", expected, target));
        }
    }
}