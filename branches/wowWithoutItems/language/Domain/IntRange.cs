using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class IntRange : IEnumerable<int>
    {
        private readonly int from;
        private readonly int to;

        public IntRange(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (var i = from; i <= to; i++)
                yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}