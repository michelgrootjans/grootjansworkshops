using System;
using DependencyInversion;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please start typing...");
            new Copy().Run();
        }
    }
}
