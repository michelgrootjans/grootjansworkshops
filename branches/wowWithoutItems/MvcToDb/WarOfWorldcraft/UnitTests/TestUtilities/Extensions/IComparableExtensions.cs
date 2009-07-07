using System;
using NUnit.Framework;

namespace UnitTests.TestUtilities.Extensions
{
    public static class IComparableExtensions
    {
        public static T ShouldBeAtLeast<T>(this T actual, T minimumValue) where T : IComparable
        {
            Assert.IsTrue(minimumValue.CompareTo(actual) <= 0, string.Format("Expected at least {0} but was {1}", minimumValue, actual));
            return actual;
        }

        public static T ShouldBeMoreThan<T>(this T actual, T minimumValue) where T : IComparable
        {
            Assert.IsTrue(minimumValue.CompareTo(actual) < 0, string.Format("Expected more than {0} but was {1}", minimumValue, actual));
            return actual;
        }

        public static T ShouldBeAtMost<T>(this T actual, T minimumValue) where T : IComparable
        {
            Assert.IsTrue(minimumValue.CompareTo(actual) >= 0, string.Format("Expected at most {0} but was {1}", minimumValue, actual));
            return actual;
        }

        public static T ShouldBeLessThan<T>(this T actual, T minimumValue) where T : IComparable
        {
            Assert.IsTrue(minimumValue.CompareTo(actual) > 0, string.Format("Expected less than {0} but was {1}", minimumValue, actual));
            return actual;
        }
    }
}