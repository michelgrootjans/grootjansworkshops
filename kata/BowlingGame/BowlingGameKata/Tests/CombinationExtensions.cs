using BowlingGameKata.Code;
using NUnit.Framework;

namespace BowlingGameKata.Tests
{
    public static class CombinationExtensions
    {
        public static void ShouldBeat(this Combination expectedWinner, Combination expectedLooser)
        {
            Assert.IsTrue(expectedWinner.Beats(expectedLooser));
            Assert.IsFalse(expectedLooser.Beats(expectedWinner));
        }        
    }
}