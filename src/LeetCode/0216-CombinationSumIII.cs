using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class CombinationSumIII
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            if (n <= 0 || k <= 0)
            {
                return new IList<int>[0];
            }

            var max = 9;
            var min = 1;

            var combinations = new List<IList<int>>();

            CombinationSum(
                k, 
                n,
                combinations,
                new List<int>(k),
                min,
                max);

            return combinations;
        }

        private void CombinationSum(
            int k, 
            int n,
            List<IList<int>> combinations,
            IEnumerable<int> numbers,
            int number,
            int max)
        {
            if (number > max || k <= 0 || number > n)
            {
                return;
            }

            if (k == 1)
            {
                if (number == n)
                {
                    combinations
                        .Add(numbers.Union(new[] { number })
                        .ToArray());
                }

                if (number >= n)
                {
                    return;
                }

                CombinationSum(k, n, combinations, numbers, number + 1, max);
            }
            else
            {
                CombinationSum(k, n, combinations, numbers, number + 1, max);

                if (number + 1 <= n - number)
                {
                    CombinationSum(
                        k - 1,
                        n - number,
                        combinations,
                        numbers.Union(new[] { number }),
                        number + 1,
                        max);
                }
            }
        }
    }
}
