using System;

namespace BowlingGameKata.Code
{
    public static class StringExtensions
    {
        public static int Rank(this string value)
        {
            switch(value)
            {
                case "A":
                    return 14;
                case "K":
                    return 13;
                case "Q":
                    return 12;
                case "J":
                    return 11;
                case "10":
                case "9":
                case "8":
                case "7":
                case "6":
                case "5":
                case "4":
                case "3":
                case "2":
                    return int.Parse(value);
                default:
                    throw new Exception(string.Format("Couldn't parse {0} to a card.", value));
            }
        }
    }
}