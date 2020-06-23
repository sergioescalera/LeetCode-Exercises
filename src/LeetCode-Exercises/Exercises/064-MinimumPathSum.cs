using LeetCode.Attributes;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class MinimumPathSum
    {
        public int MinPathSum(int[][] grid)
        {
            if (grid == null)
                throw new ArgumentNullException(nameof(grid));

            return MinPathSum(grid, 0, 0, new Dictionary<string, int>());
        }

        private int MinPathSum(
            int[][] grid, 
            int x,
            int y, 
            Dictionary<string, int> cache)
        {
            var m = grid.Length - x;
            var n = grid[0].Length - y;

            if (m < 1 || n < 1)
            {
                return -1;
            }

            var value = grid[x][y];

            if (m == 1 && n == 1)
            {
                return value;
            }

            var key = $"{m},{n}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            var right = MinPathSum(grid, x + 1, y, cache);
            var down =   MinPathSum(grid, x, y + 1, cache);

            if (right >= 0 && down >= 0)
            {
                value += Math.Min(right, down);
            }
            else if (right >= 0)
            {
                value += right;
            }
            else if (down >= 0)
            {
                value += down;
            }

            cache.Add(key, value);

            return value;
        }
    }
}
