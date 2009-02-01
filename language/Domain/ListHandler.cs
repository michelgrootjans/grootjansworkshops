using System;
using System.Collections.Generic;

namespace Domain
{
    public class ListHandler<T>
    {
        private readonly Action<T> output;
        private readonly List<Converter<T,T>> converters;
        private readonly List<Predicate<T>> conditions;

        public ListHandler(Action<T> output)
        {
            this.output = output;
            conditions = new List<Predicate<T>>();
            converters = new List<Converter<T,T>>();
        }

        public void Execute(List<T> names)
        {
            foreach (var condition in conditions)
                names = names.FindAll(condition);

            foreach (var converter in converters)
                names = names.ConvertAll(converter);

            names.ForEach(output);
        }

        public ListHandler<T> Convert(Converter<T,T> converter)
        {
            converters.Add(converter);
            return this;
        }

        public ListHandler<T> Where(Predicate<T> predicate)
        {
            conditions.Add(predicate);
            return this;
        }
    }
}