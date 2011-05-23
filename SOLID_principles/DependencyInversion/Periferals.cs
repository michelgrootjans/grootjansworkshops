using System;

namespace DependencyInversion
{
    public static class Printer
    {
        public static void Write(int i)
        {
            Console.WriteLine(i);
        }
    }

    public static class Keyboard
    {
        public static int Read()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }

}