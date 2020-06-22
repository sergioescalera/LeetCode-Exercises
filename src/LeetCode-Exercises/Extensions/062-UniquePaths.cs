using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Extensions
{
    [Exercise]
    public class UniquePathsExercise
    {
        public static void Run()
        {
            var exercise = new UniquePathsExercise();

            do
            {
                var m = exercise.ReadNum();

                if (m == null)
                    break;

                var n = exercise.ReadNum();

                if (n == null)
                    break;

                var x = exercise.UniquePaths(m.Value, n.Value);

                Console.WriteLine("{0}x{1}={2}", m, n, x);

            } while (true);
        }

        Dictionary<string, int> cache = new Dictionary<string, int>();

        public int UniquePaths(int m, int n)
        {
            if (m <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(m));
            }

            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            if (m == 1 || n == 1)
            {
                return 1;
            }

            var key = m > n ? $"{n},{m}" : $"{m},{n}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            var value = UniquePaths(m - 1, n) + UniquePaths(m, n - 1);

            cache.Add(key, value);

            return value;
        }
    }
}
