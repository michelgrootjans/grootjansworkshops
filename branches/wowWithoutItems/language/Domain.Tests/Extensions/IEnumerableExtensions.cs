using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Domain.Tests.Extensions
{
    public static class IEnumerableExtensions
    {
        public static int Count<T>(this IEnumerable<T> list)
        {
            return new List<T>(list).Count;
        }

        public static void ShouldContain<T>(this IEnumerable<T> list, T t)
        {
            Assert.IsTrue(new List<T>(list).Contains(t));
        }

        public static void ShouldContain<T>(this IEnumerable<T> list, Predicate<T> predicate)
        {
            Assert.IsTrue(new List<T>(list).Exists(predicate));
        }

        public static void ShouldNotContain<T>(this IEnumerable<T> list, T t)
        {
            Assert.IsFalse(new List<T>(list).Contains(t));
        }

        public static void ShouldNotContain<T>(this IEnumerable<T> list, Predicate<T> predicate)
        {
            Assert.IsFalse(new List<T>(list).Exists(predicate));
        }
    }
}