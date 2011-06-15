using System;

namespace Hardware
{
    public class CustomConsole
    {
        public static void HighlightLine(string message, params string[] args)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message, args);
            Console.ForegroundColor = currentColor;
        }

        public static void Highlight(string message, params string[] args)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message, args);
            Console.ForegroundColor = currentColor;
        }
    }
}