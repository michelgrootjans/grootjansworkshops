/*
 * Created by: 
 * Created: zaterdag 31 januari 2009
 */

using NUnit.Framework;

namespace Domain.Tests.Extensions
{
    public static class BoolExtensions
    {
        public static void ShouldBeTrue(this bool actual)
        {
            Assert.IsTrue(actual);
        }

        public static void ShouldBeFalse(this bool actual)
        {
            Assert.IsFalse(actual);
        }
    }
}