using System;
using System.Collections.Generic;

namespace Domain
{
    public class StringPrinter
    {
        public void Print(List<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        public void PrintToUppercase(List<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name.ToUpper());
            }
        }

        public void PrintContainingAnL(List<string> names)
        {
            foreach (var name in names)
            {
                if (name.Contains("l"))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}