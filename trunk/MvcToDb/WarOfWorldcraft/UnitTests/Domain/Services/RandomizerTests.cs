using System.Collections.Generic;
using NUnit.Framework;
using UnitTests.TestUtilities;
using WarOfWorldcraft.Domain.Services;
using UnitTests.TestUtilities.Extensions;

namespace UnitTests.Domain.Services
{
    public class when_Randomizer_is_told_to_generate_a_number_between_1_and_2 : InstanceContextSpecification<IRandomizer>
    {
        private IList<int> results;

        protected override void Arrange()
        {
            results = new List<int>();
        }

        protected override IRandomizer CreateSystemUnderTest()
        {
            return new Randomizer();
        }

        protected override void Act()
        {
            for (int i = 0; i < 100; i++)
                results.Add(sut.GetNumberBetween(1, 2));
        }

        [Test]
        public void should_NOT_return_a_0()
        {
            results.ShouldNotContain(r => r == 0);
        }

        [Test]
        public void should_NOT_return_a_1()
        {
            results.ShouldContain(r => r == 1);
        }

        [Test]
        public void should_NOT_return_a_2()
        {
            results.ShouldContain(r => r == 2);
        }

        [Test]
        public void should_NOT_return_a_3()
        {
            results.ShouldNotContain(r => r == 3);
        }

    }
}