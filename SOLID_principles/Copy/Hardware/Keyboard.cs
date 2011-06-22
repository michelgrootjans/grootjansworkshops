using System;

namespace Hardware
{
    public class Keyboard
    {
        public string Read()
        {
            Console.Write("Keyboard: ");
            return Console.ReadLine();
        }
    }
}