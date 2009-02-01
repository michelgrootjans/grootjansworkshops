using System;
using System.Collections.Generic;

namespace Domain
{
    public class NamePrinter
    {
        public void Print(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        public void PrintToUppercase(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name.ToUpper());
            }
        }

        public void PrintContainingAnL(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                if (name.Contains("l"))
                {
                    Console.WriteLine(name);
                }
            }
        }

        public void PrintToUppercaseContainingAnL(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                if (name.Contains("l"))
                {
                    Console.WriteLine(name.ToUpper());
                }
            }
        }
    }
}