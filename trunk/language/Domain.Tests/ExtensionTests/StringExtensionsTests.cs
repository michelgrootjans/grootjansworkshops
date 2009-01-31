/*
 * Created by: 
 * Created: zaterdag 31 januari 2009
 */

using Domain.Tests.Extensions;
using NUnit.Framework;
using Domain.Extensions;

namespace Domain.Tests.ExtensionTests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void should_return_true_with_null()
        {
            string test = null;
            test.IsNullOrEmpty().ShouldBeTrue();
        }

        [Test]
        public void should_return_true_with_empty_string()
        {
            "".IsNullOrEmpty().ShouldBeTrue();
        }

        [Test]
        public void should_return_false_with_an_existing_string()
        {
            "test".IsNullOrEmpty().ShouldBeFalse();
        }

    }
}