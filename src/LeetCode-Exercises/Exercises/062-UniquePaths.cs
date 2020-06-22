using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
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

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid == null)
            {
                throw new ArgumentNullException(nameof(obstacleGrid));
            }

            return UniquePathsWithObstacles(obstacleGrid, 0, 0, new Dictionary<string, int>());
        }

        private int UniquePathsWithObstacles(
            int[][] obstacleGrid,
            int x,
            int y,
            Dictionary<string, int> cache)
        {
            var m = obstacleGrid.Length - x;
            var n = obstacleGrid[0].Length - y;

            if (m < 1 || n < 1)
            {
                return 0;
            }

            if (m == 1 && n == 1)
            {
                return obstacleGrid[x][y] == 0 ? 1 : 0;
            }

            var key = $"{m},{n}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            var value = obstacleGrid[x][y] == 0 ?
                UniquePathsWithObstacles(obstacleGrid, x + 1, y, cache) +
                UniquePathsWithObstacles(obstacleGrid, x, y + 1, cache) : 0;

            cache.Add(key, value);

            return value;
        }
    }
}
