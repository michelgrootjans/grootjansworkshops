using System.Collections.Generic;

namespace BowlingGameKata.Code
{
    internal class HighCard : Combination
    {
        private readonly List<int> cards;

        public HighCard(string card1, string card2, string card3, string card4, string card5)
        {
            cards = new List<int> {card1.Rank(), card2.Rank(), card3.Rank(), card4.Rank(), card5.Rank()};
            cards.Sort();
        }

        //protected override bool CompareWithSameRank(Combination combination)
        //{
        //    var other = combination as HighCard;
        //    for (var i = 0; i < 5; i++)
        //    {
        //        if (cards[i] != other.cards[i])
        //            return cards[i] > other.cards[i];
        //    }
        //    return false;
        //}

        public override int Rank
        {
            get { return 1; }
        }
    }
}