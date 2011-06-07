using System;

namespace Copy
{
    public static class Keyboard
    {
        public static string Read()
        {
            Console.Write("Keyboard: ");
            return Console.ReadLine();
        }
    }
}