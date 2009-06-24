using NUnit.Framework;

namespace UnitTests.TestUtilities.Extensions
{
    public static class ObjectExtensions
    {
        public static T ShouldBeOfType<T>(this object target)
        {
            typeof (T).IsAssignableFrom(target.GetType()).ShouldBeTrue();
            return (T) target;
        }

        public static void ShouldBeNull(this object target)
        {
            Assert.IsNull(target);
        }

        public static void ShouldBeEqualTo(this object actual, object expected)
        {
            Assert.AreEqual(expected, actual);
        }

        public static void ShouldBeSameAs(this object actual, object expected)
        {
            Assert.AreSame(expected, actual);
        }
    }
}