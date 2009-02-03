using System.Collections.Generic;

namespace Domain
{
    public class NumberManager
    {
        public IEnumerable<int> GetNumbers(int from, int to)
        {
            var results = new List<int>();
            for (var i = from; i <= to; i++)
            {
                results.Add(i);
            }
            return results;
        }

        public IEnumerable<int> GetEvenNumbers(int from, int to)
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

        public IEnumerable<int> GetEvenNumbersInReverseOrder(int from, int to)
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