using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace dotnet2.Generics
{
    [TestFixture]
    public class List
    {
        private Converter<int, double> takeSquareRoot;
        private Predicate<int> evenNumbers;
        private List<int> integers;

        [SetUp]
        public void Setup()
        {
            takeSquareRoot = TakeSquareRoot;
            evenNumbers = IsEven;

            integers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};
        }

        [Test]
        public void print_all_integers()
        {
            integers.ForEach(Console.WriteLine);
        }

        [Test]
        public void print_all_even_integers()
        {
            integers
                .FindAll(evenNumbers)
                .ForEach(Console.WriteLine);
        }

        [Test]
        public void print_all_square_roots()
        {
            integers
                .ConvertAll(takeSquareRoot)
                .ForEach(Console.WriteLine);
        }

        private static bool IsEven(int x)
        {
            return x %2 == 0;
        }

        private static double TakeSquareRoot(int x)
        {
            return Math.Sqrt(x);
        }
    }
}