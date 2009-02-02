using System.Collections.Generic;

namespace Domain
{
    public class IntRange
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
    }
}