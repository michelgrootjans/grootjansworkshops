using System;
using System.Collections.Generic;

namespace Domain.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            new List<T>(list).ForEach(action);
        }
        public static IEnumerable<TOutput> ConvertAll<TInput, TOutput>(this IEnumerable<TInput> list, Converter<TInput, TOutput> converter)
        {
            return new List<TInput>(list).ConvertAll(converter);
        }
    }
}