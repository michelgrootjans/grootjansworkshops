namespace VideoStore
{
    public class Movie
    {
        internal const int REGULAR = 0;
        internal const int NEW_RELEASE = 1;
        internal const int CHILDRENS = 2;


        public Movie(string title, int priceCode)
        {
            this.title = title;
            this.priceCode = priceCode;
        }

        private string title;
        public string Title
        {
            get { return title; }
        }

        private int priceCode;
        public int PriceCode
        {
            get { return priceCode; }
            set { priceCode = value; }
        }
    }
}