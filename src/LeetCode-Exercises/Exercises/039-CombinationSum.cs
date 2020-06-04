using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class CombinationSumExercise
    {
        public static void Run()
        {

        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            if (target < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (target == 0)
            {
                return new IList<int>[] { new int[0] };
            }

            if (candidates == null || candidates.Length == 0)
            {
                return new IList<int>[0];
            }

            return CombinationSum(candidates, target, 0);
        }

        private IList<IList<int>> CombinationSum(int[] candidates, int target, int index)
        {
            if (index >= candidates.Length)
            {
                return new IList<int>[0];
            }

            var n = candidates[index];

            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException($"candidates[{index}]");
            }

            var count = target / n;
            var results = new List<IList<int>>();

            for (int i = count; i >= 0; i--)
            {
                var r = target - i * n;

                var l = Enumerable.Repeat(n, i);

                if (i == 0)
                {
                    var combinations = CombinationSum(candidates, r, index + 1);

                    results.AddRange(combinations);
                }
                else if (r == 0)
                {
                    results.Add(l.ToList());
                }
                else
                {
                    var combinations = CombinationSum(candidates, r, index + 1);

                    foreach (var list in combinations)
                    {
                        results.Add(l.Concat(list).ToList());
                    }
                }
            }

            return results;
        }
    }
}
