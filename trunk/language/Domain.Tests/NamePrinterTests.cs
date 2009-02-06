using System.Collections.Generic;
using Domain.Tests.Extensions;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class NamePrinterTests
    {
        private IEnumerable<string> names;
        private NamePrinter namePrinter;
        private List<string> result;
        private const string albertEinstein = "Albert Einstein";
        private const string johnCleese = "John Cleese";
        private const string georgeBush = "George W. Bush";

        [SetUp]
        public void SetUp()
        {
            result = new List<string>();
            names = new List<string>{albertEinstein, johnCleese, georgeBush};
            namePrinter = new NamePrinter(n => result.Add(n));
        }

        [Test]
        public void test_print()
        {
            namePrinter.Print(names);

            result.Count().ShouldBeEqualTo(3);
            result.ShouldContain(albertEinstein);
            result.ShouldContain(johnCleese);
            result.ShouldContain(georgeBush);
        }

        [Test]
        public void test_print_to_uppercase()
        {
            namePrinter.PrintToUppercase(names);

            result.Count().ShouldBeEqualTo(3);
            result.ShouldContain(albertEinstein.ToUpper());
            result.ShouldContain(johnCleese.ToUpper());
            result.ShouldContain(georgeBush.ToUpper());
        }

        [Test]
        public void test_print_all_geniuses()
        {
            namePrinter.PrintGenius(names);

            result.Count().ShouldBeEqualTo(2);
            result.ShouldContain(albertEinstein);
            result.ShouldContain(johnCleese);
            result.ShouldNotContain(georgeBush);
        }

        [Test]
        public void test_print_geniuses_to_uppercase()
        {
            namePrinter.PrintGeniusToUpperCase(names);

            result.Count().ShouldBeEqualTo(2);
            result.ShouldContain(albertEinstein.ToUpper());
            result.ShouldContain(johnCleese.ToUpper());
            result.ShouldNotContain(georgeBush.ToUpper());
        }
    }
}