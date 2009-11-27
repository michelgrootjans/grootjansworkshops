using BowlingGameKata.Code;
using NUnit.Framework;

namespace BowlingGameKata.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Pair_ShouldBeat_HighCard()
        {
            var pair = new Pair("2", "3", "4", "5");
            var highCard = new HighCard("A", "K", "Q", "J", "9");
            pair.ShouldBeat(highCard);
        }

        [Test]
        public void TwoPairs_ShouldBeat_Pair()
        {
            var pair = new Pair("A", "K", "Q", "J");
            var twoPairs = new TwoPairs("2", "3", "4");
            twoPairs.ShouldBeat(pair);
        }

        [Test]
        public void ThreeOfAKind_ShouldBeat_TwoPairs()
        {
            var twoPairs = new TwoPairs("A", "K", "Q");
            var threeOfAKind = new ThreeOfAKind("2", "3", "4");
            threeOfAKind.ShouldBeat(twoPairs);
        }

        [Test]
        public void Straight_ShouldBeat_ThreeOfAKind()
        {
            var threeOfAKind = new ThreeOfAKind("A", "K", "Q");
            var straight = new Straight("6");
            straight.ShouldBeat(threeOfAKind);
        }

        [Test]
        public void Flush_ShouldBeat_Straight()
        {
            var straight = new Straight("A");
            var flush = new Flush(Suit.Hearts, "2", "3", "4", "5", "7");
            flush.ShouldBeat(straight);
        }

        [Test]
        public void FullHouse_ShouldBeat_Flush()
        {
            var flush = new Flush(Suit.Hearts, "A", "K", "Q", "J", "9");
            var fullHouse = new FullHouse("2", "3");
            fullHouse.ShouldBeat(flush);
        }

        [Test]
        public void FourOfAKind_ShouldBeat_FullHouse()
        {
            var fullHouse = new FullHouse("2", "3");
            var fourOfAKind = new FourOfAKind("2", "3");
            fourOfAKind.ShouldBeat(fullHouse);
        }

        [Test]
        public void StraightFlush_ShouldBeat_FourOfAKind()
        {
            var straightFlush = new StraightFlush(Suit.Hearts, "6");
            var fourOfAKind = new FourOfAKind("A", "K");
            straightFlush.ShouldBeat(fourOfAKind);
        }
    }
}