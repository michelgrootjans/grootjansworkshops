using System;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IRandomizer
    {
        int GetNumberBetween(int from, int to);
    }

    internal class Randomizer : IRandomizer
    {
        private static readonly Random Rnd = new Random();
        
        public int GetNumberBetween(int from, int to)
        {
            return Rnd.Next(from, to + 1);
        }
    }
}