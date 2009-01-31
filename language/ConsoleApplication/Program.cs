using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string> {"Albert Einstein", "John Cleese", "George W. Bush"};
            var stringPrinter = new StringPrinter();
            stringPrinter.Print(names);
            Console.ReadLine();
        }
    }
}
