using NUnit.Framework;

namespace UnitTests.TestUtilities.Extensions
{
    public static class BoolExtensions
    {
        public static void ShouldBeTrue(this bool condition)
        {
            Assert.IsTrue(condition);
        }
    }
}