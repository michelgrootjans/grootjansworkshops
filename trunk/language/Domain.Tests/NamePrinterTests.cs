using System.Collections.Generic;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class NamePrinterTests
    {
        private IEnumerable<string> names;
        private NamePrinter namePrinter;

        [SetUp]
        public void SetUp()
        {
            names = new List<string>
                        {
                            "Albert Einstein",
                            "John Cleese",
                            "George W. Bush"
                        };
            namePrinter = new NamePrinter();
        }

        [Test]
        public void test_print()
        {
            namePrinter.Print(names);
        }

        [Test]
        public void test_print_to_uppercase()
        {
            namePrinter.PrintToUppercase(names);
        }

        [Test]
        public void test_print_all_names_containing_an_L()
        {
            namePrinter.PrintContainingAnL(names);
        }

        [Test]
        public void test_print_to_uppercase_containing_an_L()
        {
            namePrinter.PrintToUppercaseContainingAnL(names);
        }
    }
}