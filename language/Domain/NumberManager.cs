using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class NumberManager
    {
        public IEnumerable<int> GetNumbers(int from, int to)
        {
            return Enumerable.Range(from, to);
        }

        public IEnumerable<int> GetEvenNumbers(int from, int to)
        {
            return GetNumbers(from, to).Where(n => n%2 == 0);
        }

        public IEnumerable<int> GetEvenNumbersInReverseOrder(int from, int to)
        {
            return GetEvenNumbers(from, to).Reverse();
        }
    }
}