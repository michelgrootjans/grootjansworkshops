using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class IteratorsTests
    {
        [Test]
        public void test_a_simple_int_range()
        {
            var from1To10 = new IntRange(1, 10);
            //iterate through the range
        }
    }
}