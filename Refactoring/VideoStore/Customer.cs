using System.Collections.Generic;

namespace VideoStore
{
    public class Customer
    {
        private string name;
        private List<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            this.name = name;
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public string Name
        {
            get { return name; }
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + Name + "\n";

            foreach (var rental in rentals)
            {
                double thisAmount = 0;
                switch (rental.Movie.PriceCode)
                {
                    //determine amount for each line
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (rental.DaysRented > 2)
                            thisAmount += (rental.DaysRented - 2)*1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += rental.DaysRented * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (rental.DaysRented > 3)
                            thisAmount += (rental.DaysRented - 3) * 1.5;
                        break;
                }

                //add frequent renter points
                frequentRenterPoints++;
                //add bonus for a two day new release rental
                if (rental.Movie.PriceCode == Movie.NEW_RELEASE && rental.DaysRented > 1)
                    frequentRenterPoints++;
                //show figures for this rental
                result += "\t" + rental.Movie.Title + "\t" + thisAmount.ToString() + "\n";

                totalAmount += thisAmount;
            }

            //add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}