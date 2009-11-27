namespace BowlingGameKata.Code
{
    public class Flush : Combination
    {
        public Flush(Suit suit, string card1, string card2, string card3, string card4, string card5)
        {
        }

        public override int Rank
        {
            get { return 6; }
        }
    }
}