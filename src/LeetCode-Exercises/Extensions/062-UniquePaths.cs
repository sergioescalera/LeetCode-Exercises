﻿using LeetCode.Attributes;
using System;
using System.Collections.Generic;

namespace LeetCode.Extensions
{
    [Exercise]
    public class UniquePathsExercise
    {
        public static void Run()
        {

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

            var key = $"{m},{n}";

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
