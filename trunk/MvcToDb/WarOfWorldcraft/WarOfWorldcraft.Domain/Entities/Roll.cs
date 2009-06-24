using System;

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
        private static readonly Random Random = new Random();
        private readonly int numberOfEyes;

        public DieRoll(int numberOfEyes)
        {
            this.numberOfEyes = numberOfEyes;
        }

        public int Once()
        {
            return Random.Next(1, numberOfEyes + 1);
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