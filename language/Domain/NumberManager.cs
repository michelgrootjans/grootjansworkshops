using System.Collections.Generic;

namespace Domain
{
    public class NumberManager
    {
        public List<int> PrintFromTo(int from, int to)
        {
            var results = new List<int>();
            for (var i = from; i <= to; i++)
            {
                results.Add(i);
            }
            return results;
        }

        public List<int> PrintEvenNumbersFromTo(int from, int to)
        {
            var results = new List<int>();
            for (var i = from; i <= to; i++)
            {
                if (i%2 == 0)
                {
                    results.Add(i);
                }
            }
            return results;
        }

        public List<int> PrintEvenNumbersInReverseOrder(int from, int to)
        {
            var results = new List<int>();
            for (var i = to; i >= from; i--)
            {
                if (i%2 == 0)
                {
                    results.Add(i);
                }
            }
            return results;
        }
    }
}