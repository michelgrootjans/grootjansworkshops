using NUnit.Framework;
using Sim_U_Duck.Ducks;

namespace Sim_U_Duck.Tests
{
    [TestFixture]
    public class MallardDuckTests
    {
        private Duck duck;

        [SetUp]
        public void SetUp()
        {
            duck = new MallardDuck();
        }

        [Test]
        public void test_simple_quack()
        {
            duck.Quack();
        }

    }
}