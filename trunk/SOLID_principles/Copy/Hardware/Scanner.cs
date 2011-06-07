using System;

namespace Hardware
{
    public class Scanner
    {
        public static string Read()
        {
            Console.Write("Scanner: ");
            return Console.ReadLine();
        }
    }
}