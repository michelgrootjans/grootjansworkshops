using NUnit.Framework;

namespace UnitTests.TestUtilities.Extensions
{
    public static class ObjectExtensions
    {
        public static T ShouldBeOfType<T>(this object target)
        {
            if (! typeof (T).IsAssignableFrom(target.GetType()))
            {
                throw new AssertionException(string.Format("{0} is not of expected type {1}",
                    target.GetType().Name, typeof (T).Name));
            }
            return (T) target;
        }

        public static void ShouldBeNull(this object target)
        {
            Assert.IsNull(target);
        }

        public static void ShouldNotBeNull(this object target)
        {
            Assert.IsNotNull(target);
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