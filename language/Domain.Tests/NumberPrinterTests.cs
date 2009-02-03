using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class NumberPrinterTests
    {
        private NumberManager numberManager;
        private IEnumerable<int> results;

        [SetUp]
        public void SetUp()
        {
            numberManager = new NumberManager();
        }

        [Test]
        public void print_numbers_from_1_to_10()
        {
            results = numberManager.GetNumbers(1, 10);

            foreach (var i in results)
                Console.WriteLine(i);
        }

        [Test]
        public void print_even_numbers_from_1_to_10()
        {
            results = numberManager.GetEvenNumbers(1, 10);

            foreach (var i in results)
                Console.WriteLine(i);
        }

        [Test]
        public void print_even_numbers_in_reverse_order()
        {
            results = numberManager.GetEvenNumbersInReverseOrder(1, 10);

            foreach (var i in results)
                Console.WriteLine(i);
        }
    }
}