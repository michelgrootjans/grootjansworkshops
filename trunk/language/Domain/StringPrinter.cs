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

        public void PrintInUppercase(List<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name.ToUpper());
            }
        }

        public void PrintContainingAnE(List<string> names)
        {
            foreach (var name in names)
            {
                if (name.Contains("e"))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}