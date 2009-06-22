using System;

namespace WarOfWorldcraft.Domain.Entities
{
    internal static class Roll
    {
        public static IRoll SixSidedDice()
        {
            return new DieRoll(6);
        }
    }

    internal interface IRoll
    {
        int Once();
        int Twice();
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
    }
}