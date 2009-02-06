using System.Collections.Generic;

namespace Domain
{
    public class NumberManager
    {
        public List<int> GetNumbers(int from, int to)
        {
            var results = new List<int>();
            for (var i = from; i <= to; i++)
            {
                results.Add(i);
            }
            return results;
        }

        public List<int> GetEvenNumbers(int from, int to)
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

        public List<int> GetEvenNumbersInReverseOrder(int from, int to)
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