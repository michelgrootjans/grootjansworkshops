using System;

namespace Hardware
{
    public class Email
    {
        public static void Send(string text)
        {
            Console.Write("Email address: ");
            string emailAddress = Console.ReadLine();

            Console.WriteLine("***");
            Console.WriteLine("To:      {0}", emailAddress);
            Console.WriteLine("Message: {0}", text);
            Console.WriteLine("***");
            Console.WriteLine();
        }
    }
}