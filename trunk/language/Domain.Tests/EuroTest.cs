using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class EuroTest
    {
        [Test]
        public void euro_initialization_sets_amount()
        {
            var oneEuro = new Euro(1);
            Assert.AreEqual(1, oneEuro.Amount);
        }

        [Test]
        public void euro_can_be_added()
        {
            var oneEuro = new Euro(1);
            var twoEuro = oneEuro + oneEuro;
            Assert.AreEqual(2, twoEuro.Amount);
        }

        [Test]
        public void a_double_can_be_added_to_euro()
        {
            var oneEuro = new Euro(1);
            var twoEuro = oneEuro + 1;
            Assert.AreEqual(2, twoEuro.Amount);
        }
    }
}