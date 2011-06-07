using System;

namespace Hardware
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