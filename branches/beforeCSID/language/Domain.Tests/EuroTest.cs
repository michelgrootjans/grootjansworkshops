using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class EuroTest
    {
        private Euro oneEuro;

        [SetUp]
        public void SetUp()
        {
            oneEuro = new Euro(1);
        }

        [Test]
        public void verify_the_amount()
        {
            Assert.AreEqual(1, oneEuro.Amount);
        }

        [Test]
        public void test_the_addition_of_euro()
        {
        }

        [Test]
        public void add_a_sum_to_the_amount()
        {
        }
    }
}