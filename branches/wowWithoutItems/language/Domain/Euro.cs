namespace Domain
{
    public class Euro
    {
        public readonly double Amount;

        public Euro(double amount)
        {
            Amount = amount;
        }

        public static Euro operator +(Euro x, Euro y)
        {
            return new Euro(x.Amount + y.Amount);
        }

        public static implicit operator Euro(double amount)
        {
            return new Euro(amount);
        }
    }
}