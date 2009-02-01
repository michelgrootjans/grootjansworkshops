namespace Domain
{
    public class Euro
    {
        public double Amount { get; private set; }

        public Euro(double amount)
        {
            Amount = amount;
        }

        public static Euro operator +(Euro money1, Euro money2)
        {
            return new Euro(money1.Amount + money2.Amount);
        }

        public static implicit operator Euro(double money)
        {
            return new Euro(money);
        }
    }
}