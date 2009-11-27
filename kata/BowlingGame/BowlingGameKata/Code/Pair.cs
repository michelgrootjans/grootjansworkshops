using System.Collections.Generic;

namespace BowlingGameKata.Code
{
    internal class Pair : Combination
    {
        private readonly int pairCards;
        private List<int> otherCards;

        public Pair(string pairCards, string card3, string card4, string card5)
        {
        }

        public override int Rank
        {
            get { return 2; }
        }
    }
}