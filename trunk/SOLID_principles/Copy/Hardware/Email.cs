using System;

namespace Hardware
{
    public class Email
    {
        public static void Write(string text)
        {
            Console.WriteLine("Sending email: " + text);
        }
    }
}