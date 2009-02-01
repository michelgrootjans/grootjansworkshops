using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class IntRange : IEnumerable<int>
    {
        private readonly List<int> items;

        public IntRange(int from, int to)
        {
            items = new List<int>();
            for (var i = from; i <= to; i++)
            {
                items.Add(i);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}