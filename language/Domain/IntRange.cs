namespace Domain
{
    public class IntRange : Range<int>
    {
        public IntRange(int from, int to) : base(from, to)
        {
        }

        protected override int GetNextValue(int value)
        {
            return value + 1;
        }
    }
}