namespace BowlingGameKata.Code
{
    public abstract class Combination
    {
        public bool Beats(Combination combination)
        {
            return Rank > combination.Rank;
        }

        public abstract int Rank { get; }
    }
}