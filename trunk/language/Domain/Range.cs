using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public abstract class Range<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly T from;
        private readonly T to;

        protected Range(T from, T to)
        {
            this.from = from;
            this.to = to;
        }

        protected abstract T GetNextValue(T value);

        public IEnumerator<T> GetEnumerator()
        {
            var result = new List<T>();
            T value = from;
            while (value.CompareTo(to) <= 0)
            {
                result.Add(value);
                value = GetNextValue(value);
            }
            return result.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}