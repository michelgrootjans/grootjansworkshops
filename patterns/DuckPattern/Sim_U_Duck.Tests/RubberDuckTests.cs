using NUnit.Framework;
using Sim_U_Duck.Ducks;

namespace Sim_U_Duck.Tests
{
    [TestFixture]
    public class RubberDuckTests
    {
        private Duck duck;

        [SetUp]
        public void SetUp()
        {
            duck = new RubberDuck();
        }

        [Test]
        public void test_simple_quack()
        {
            duck.Quack();
        }

    }
}