namespace BowlingGameKata.Code
{
    public class StraightFlush : Combination
    {
        public StraightFlush(Suit suit, string hightCard)
        {
        }

        public override int Rank
        {
            get { return 9; }
        }
    }
}