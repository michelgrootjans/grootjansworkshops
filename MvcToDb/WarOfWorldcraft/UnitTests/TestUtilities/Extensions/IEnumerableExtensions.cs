using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace UnitTests.TestUtilities.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> ShouldContain<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            Assert.IsTrue(list.Any(predicate));
            return list;
        }

        public static IEnumerable<T> ShouldContain<T>(this IEnumerable<T> list, T t)
        {
            Assert.IsTrue(list.Contains(t));
            return list;
        }
    }
}