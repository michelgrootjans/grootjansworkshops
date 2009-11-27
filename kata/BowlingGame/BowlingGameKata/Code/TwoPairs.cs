namespace BowlingGameKata.Code
{
    public class TwoPairs : Combination
    {
        public TwoPairs(string pair1, string pair2, string lastCard)
        {
        }

        public override int Rank
        {
            get { return 3; }
        }
    }
}