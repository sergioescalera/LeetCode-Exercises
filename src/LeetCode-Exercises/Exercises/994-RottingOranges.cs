using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class RottingOranges
    {
        public int OrangesRotting(int[][] grid)
        {
            if (grid == null)
            {
                throw new ArgumentNullException(nameof(grid));
            }

            FindRotten(
                grid, 
                out var rotten, 
                out var fresh);

            var time = 0;

            while (rotten.Any())
            {
                var current = rotten.Dequeue();

                time = current.val;

                var above = fresh.Above(grid, current);

                var below = fresh.Below(grid, current);

                var next = fresh.Next(grid, current);

                var prev = fresh.Prev(grid, current);

                var newRotten = new[] { above, below, next, prev };

                foreach (var item in newRotten.Where(o => o != null))
                {
                    item.val = current.val + 1;

                    fresh.Remove(item);

                    rotten.Enqueue(item);
                }
            }

            if (fresh.Any())
            {
                return -1;
            }

            return time;
        }

        private void FindRotten(
            int[][] grid, 
            out Queue<Point> rotten,
            out HashSet<Point> fresh)
        {
            if (grid == null)
            {
                throw new ArgumentNullException(nameof(grid));
            }

            rotten = new Queue<Point>();
            fresh = new HashSet<Point>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        rotten.Enqueue(new Point
                        {
                            x = i,
                            y = j
                        });
                    }

                    if (grid[i][j] == 1)
                    {
                        fresh.Add(new Point
                        {
                            x = i,
                            y = j
                        });
                    }
                }
            }
        }
    }

    class Point
    {
        public int x;

        public int y;

        public int val;

        public override bool Equals(object obj)
        {
            return obj is Point p && p.x == x && p.y == y;
        }

        public override int GetHashCode()
        {
            return $"{x},{y}".GetHashCode();
        }
    }

    static class PointExtensions
    {
        public static Point Above(
            this ICollection<Point> points,
            int[][] grid,
            Point current)
        {
            if (current.x > 0 && grid[current.x - 1][current.y] == 1)
            {
                return points.FirstOrDefault(o => o.x == current.x - 1 && o.y == current.y);
            }

            return null;
        }

        public static Point Below(
            this ICollection<Point> points,
            int[][] grid,
            Point current)
        {
            if (current.x < grid.Length - 1 && grid[current.x + 1][current.y] == 1)
            {
                return points.FirstOrDefault(o => o.x == current.x + 1 && o.y == current.y);
            }

            return null;
        }

        public static Point Prev(
            this ICollection<Point> points,
            int[][] grid,
            Point current)
        {
            if (current.y > 0 && grid[current.x][current.y - 1] == 1)
            {
                return points.FirstOrDefault(o => o.x == current.x && o.y == current.y - 1);
            }

            return null;
        }

        public static Point Next(
            this ICollection<Point> points,
            int[][] grid,
            Point current)
        {
            if (current.y < grid[current.x].Length - 1 && grid[current.x][current.y + 1] == 1)
            {
                return points.FirstOrDefault(o => o.x == current.x && o.y == current.y + 1);
            }

            return null;
        }
    }
}
