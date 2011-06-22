using System;
using System.Threading;

namespace Hardware
{
    public static class CustomConsole
    {
        public static void HighlightLine(string message, params string[] args)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message, args);
            Console.ForegroundColor = currentColor;
            Thread.Sleep(500);
        }

        public static void Highlight(string message, params string[] args)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message, args);
            Console.ForegroundColor = currentColor;
            Thread.Sleep(2000);
        }

        public static void WriteLine(string message, params string[] args)
        {
            Console.WriteLine(message, args);
            Thread.Sleep(500);
        }

        public static void Write(string message, params string[] args)
        {
            Console.Write(message, args);
            Wait(8);
        }

        private static void Wait(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Thread.Sleep(250);
                Console.Write(".");
            }
        }

    }
}