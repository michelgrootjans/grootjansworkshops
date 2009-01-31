using System.Collections.Generic;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class GenericListTests
    {
        private List<string> names;
        private StringPrinter stringPrinter;

        [SetUp]
        public void SetUp()
        {
            names = new List<string> { "Albert Einstein", "John Cleese", "George W. Bush" };
            stringPrinter = new StringPrinter();
        }

        [Test]
        public void test_print()
        {
            stringPrinter.Print(names);
        }

        [Test]
        public void test_print_to_uppercase()
        {
            stringPrinter.PrintToUppercase(names);
        }

        [Test]
        public void test_print_all_names_containing_an_L()
        {
            stringPrinter.PrintContainingAnL(names);
        }
    }
}