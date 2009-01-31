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
            names = new List<string> {"Michel", "Koen", "Giovanni"};
            stringPrinter = new StringPrinter();
        }

        [Test]
        public void test_for_each_name()
        {
            stringPrinter.Print(names);
            stringPrinter.PrintInUppercase(names);
            stringPrinter.PrintContainingAnE(names);
        }
    }
}