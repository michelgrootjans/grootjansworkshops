using System;

namespace Hardware
{
    public class Keyboard
    {
        public static string Read()
        {
            Console.Write("Keyboard: ");
            return Console.ReadLine();
        }
    }
}