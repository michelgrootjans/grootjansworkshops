using System;

namespace Hardware
{
    public class Email
    {
        public static void Send(string userName, string text)
        {
            Console.WriteLine("*** To {0}: {1}", userName, text);
            Console.WriteLine();
        }
    }
}