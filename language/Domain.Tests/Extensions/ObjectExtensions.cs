/*
 * Created by: 
 * Created: zaterdag 31 januari 2009
 */

using NUnit.Framework;

namespace Domain.Tests.Extensions
{
    public static class ObjectExtensions
    {
        public static object ShouldBeEqualTo(this object actual, object expected)
        {
            Assert.AreEqual(expected, actual);
            return actual;
        }
    }
}