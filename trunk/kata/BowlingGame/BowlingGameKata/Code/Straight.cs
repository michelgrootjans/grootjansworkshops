namespace BowlingGameKata.Code
{
    public class Straight : Combination
    {
        public Straight(string highestCard)
        {
        }

        public override int Rank
        {
            get { return 5; }
        }
    }
}