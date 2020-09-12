using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class CombinationSumIII
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            var max = 9;
            var min = 1;

            if (n <= 0 ||
                k <= 0 ||
                k > max)
            {
                return new IList<int>[0];
            }

            var topKSum = TopKSum(max, k);
            var bottomKSum = TopKSum(min + k - 1, k);

            if (topKSum < n)
            {
                return new IList<int>[0];
            }

            if (topKSum == n)
            {
                return new IList<int>[]
                {
                    Enumerable.Range(max - k + 1, k).ToArray()
                };
            }

            if (n < bottomKSum)
            {
                return new IList<int>[0];
            }

            if (bottomKSum == n)
            {
                return new IList<int>[]
                {
                    Enumerable.Range(min, k).ToArray()
                };
            }

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
            Console.WriteLine($"{number}: {n}");

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
                if (number + 1 <= n - number && number < max)
                {
                    var topKSum = TopKSum(max, k - 1);
                    var bottomKSum = TopKSum(number + k - 1, k - 1);

                    if (bottomKSum <= n - number && n - number <= topKSum)
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

                if (max - number >= k)
                {
                    var topKSum = TopKSum(max, k);
                    var bottomKSum = TopKSum(number + k, k);

                    if (bottomKSum <= n && n <= topKSum)
                    {
                        CombinationSum(k, n, combinations, numbers, number + 1, max);
                    }
                }
            }
        }

        private int TopKSum(int max, int k)
        {
            return (max * (max + 1) / 2) - ((max - k) * (max - k + 1) / 2);
        }
    }
}
