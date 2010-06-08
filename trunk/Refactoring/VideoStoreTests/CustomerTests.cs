using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using VideoStore;

namespace VideoStoreTests
{
    [TestFixture]
    public class CustomerTests
    {
        private const string CUSTOMER_NAME = "Danny Gladines";
        private Customer customer;
        private string expectedStatement;

        [SetUp]
        public void Setup()
        {
            customer = new Customer(CUSTOMER_NAME);
            expectedStatement = string.Format("Rental Record for {0}\n", CUSTOMER_NAME);
        }

        [Test]
        public void CustomerHasAName()
        {
            Assert.That(customer.Name, Is.EqualTo(CUSTOMER_NAME));
        }

        [Test]
        public void NewCustomerHasAnEmptyStatement()
        {
            expectedStatement += "Amount owed is 0\n";
            expectedStatement += "You earned 0 frequent renter points";
            Assert.That(customer.Statement(), Is.EqualTo(expectedStatement));
        }

        [Test]
        public void CustomerWithOneSimpleRental()
        {
            var regularMovie = new Movie("The dirty dozen", Movie.REGULAR);
            customer.AddRental(new Rental(regularMovie, 1));

            expectedStatement += "\tThe dirty dozen\t2\n";
            expectedStatement += "Amount owed is 2\n";
            expectedStatement += "You earned 1 frequent renter points";
            Assert.That(customer.Statement(), Is.EqualTo(expectedStatement));
        }

        [Test]
        public void CustomerWithOneSimpleRental_ForThreeDays()
        {
            var regularMovie = new Movie("The dirty dozen", Movie.REGULAR);
            customer.AddRental(new Rental(regularMovie, 3));

            expectedStatement += "\tThe dirty dozen\t3,5\n";
            expectedStatement += "Amount owed is 3,5\n";
            expectedStatement += "You earned 1 frequent renter points";
            Assert.That(customer.Statement(), Is.EqualTo(expectedStatement));
        }

        [Test]
        public void CustomerWithNewRelease()
        {
            var newMovie = new Movie("Harry Potter 7", Movie.NEW_RELEASE);
            customer.AddRental(new Rental(newMovie, 1));

            expectedStatement += "\tHarry Potter 7\t3\n";
            expectedStatement += "Amount owed is 3\n";
            expectedStatement += "You earned 1 frequent renter points";
            Assert.That(customer.Statement(), Is.EqualTo(expectedStatement));
        }

        [Test]
        public void CustomerWithNewRelease_ForTwoDays_GetsExtraPoints()
        {
            var newMovie = new Movie("Harry Potter 7", Movie.NEW_RELEASE);
            customer.AddRental(new Rental(newMovie, 2));

            expectedStatement += "\tHarry Potter 7\t6\n";
            expectedStatement += "Amount owed is 6\n";
            expectedStatement += "You earned 2 frequent renter points";
            Assert.That(customer.Statement(), Is.EqualTo(expectedStatement));
        }

        [Test]
        public void CustomerWithChildrensMovie()
        {
            var kidsMovie = new Movie("Wall-e", Movie.CHILDRENS);
            customer.AddRental(new Rental(kidsMovie, 1));

            expectedStatement += "\tWall-e\t1,5\n";
            expectedStatement += "Amount owed is 1,5\n";
            expectedStatement += "You earned 1 frequent renter points";
            Assert.That(customer.Statement(), Is.EqualTo(expectedStatement));
        }

        [Test]
        public void CustomerWithChildrensMovie_ForFourDays()
        {
            var kidsMovie = new Movie("Wall-e", Movie.CHILDRENS);
            customer.AddRental(new Rental(kidsMovie, 4));

            expectedStatement += "\tWall-e\t3\n";
            expectedStatement += "Amount owed is 3\n";
            expectedStatement += "You earned 1 frequent renter points";
            Assert.That(customer.Statement(), Is.EqualTo(expectedStatement));
        }

    }
}