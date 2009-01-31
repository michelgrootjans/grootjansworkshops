using System;
using System.Collections.Generic;
using Domain;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var names = new List<string> {"Albert Einstein", "John Cleese", "George W. Bush"};
            var namePrinter = new NamePrinter();
            namePrinter.PrintToUppercaseContainingAnL(names);

            Console.ReadLine();
        }
    }
}