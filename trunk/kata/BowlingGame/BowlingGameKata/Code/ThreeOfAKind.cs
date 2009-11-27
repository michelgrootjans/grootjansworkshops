namespace BowlingGameKata.Code
{
    public class ThreeOfAKind : Combination
    {
        public ThreeOfAKind(string trio, string card4, string card5)
        {
            
        }

        public override int Rank
        {
            get { return 4; }
        }
    }
}