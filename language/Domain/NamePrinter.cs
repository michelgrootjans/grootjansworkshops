using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Extensions;

namespace Domain
{
    public class NamePrinter
    {
        private readonly Action<string> output;
        private readonly Converter<string, string> toUpperCase;
        private Func<string, bool> isGenius;

        public NamePrinter(Action<string> output)
        {
            this.output = output;
            toUpperCase = (input => input.ToUpper());
            isGenius = (input => input.Contains("l"));
        }

        public void Print(IEnumerable<string> names)
        {
            names.ForEach(output);
        }

        public void PrintToUppercase(IEnumerable<string> names)
        {
            names.ConvertAll(toUpperCase).ForEach(output);
        }

        public void PrintGenius(IEnumerable<string> names)
        {
            names.Where(isGenius).ForEach(output);
        }

        public void PrintGeniusToUpperCase(IEnumerable<string> names)
        {
            names.Where(isGenius).ConvertAll(toUpperCase).ForEach(output);
        }
    }
}