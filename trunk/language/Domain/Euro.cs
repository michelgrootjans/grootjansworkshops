namespace Domain
{
    public class Euro
    {
        public double Amount { get; private set; }

        public Euro(double amount)
        {
            Amount = amount;
        }
    }
}