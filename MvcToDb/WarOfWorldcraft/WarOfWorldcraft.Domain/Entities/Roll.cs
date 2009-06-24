using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Utilities.IoC;

namespace WarOfWorldcraft.Domain.Entities
{
    internal static class Roll
    {
        public static IRoll SixSidedDice()
        {
            return new DieRoll(6);
        }

        public static IRoll TenSidedDice()
        {
            return new DieRoll(10);
        }
    }

    internal interface IRoll
    {
        int Once();
        int Twice();
        int Times(int times);
    }

    internal class DieRoll : IRoll
    {
        private readonly int numberOfEyes;
        private readonly IRandomizer randomizer;

        public DieRoll(int numberOfEyes)
        {
            this.numberOfEyes = numberOfEyes;
            randomizer = Container.GetImplementationOf<IRandomizer>();
        }

        public int Once()
        {
            return randomizer.GetNumberBetween(1, numberOfEyes);
        }

        public int Twice()
        {
            return Once() + Once();
        }

        public int Times(int times)
        {
            var roll = 0;
            for (var i = 0; i < times; i++)
            {
                roll += Once();
            }
            return roll;
        }
    }
}