using System.Collections.Generic;

namespace LeetCode
{
    public class UniquePathsIIISolution
    {
        public int UniquePathsIII(int[][] grid)
        {
            if (grid == null)
            {
                return 0;
            }

            var start = FindStart(grid);
            var visited = new bool[grid.Length][];

            for (int i = 0; i < grid.Length; i++)
            {
                visited[i] = new bool[grid[i].Length];
            }

            var pending = CountNonObstacle(grid) + 1;

            visited[start.x][start.y] = true;

            return UniquePathsIII(
                grid, 
                visited,
                pending,
                start);
        }

        private Point FindStart(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        return new Point { x = i, y = j, val = grid[i][j] };
                    }
                }
            }

            return null;
        }

        private int CountNonObstacle(int[][] grid)
        {
            var count = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private int UniquePathsIII(
            int[][] grid, 
            bool[][] visited,
            int pendingVisit,
            Point point)
        {
            if (point.val == 2)
            {
                return pendingVisit == 0 ? 1 : 0;
            }

            var count = 0;

            foreach (var adjacent in GetAdjacents(grid, visited, point))
            {
                visited[adjacent.x][adjacent.y] = true;

                count += UniquePathsIII(
                    grid, 
                    visited, 
                    pendingVisit - 1,
                    adjacent);

                visited[adjacent.x][adjacent.y] = false;
            }

            return count;
        }

        private IEnumerable<Point> GetAdjacents(
            int[][] grid, 
            bool[][] visited, 
            Point point)
        {
            if (point.x < grid.Length - 1 &&
                grid[point.x + 1][point.y] != -1 &&
                visited[point.x + 1][point.y] == false)
            {
                yield return new Point
                {
                    x = point.x + 1,
                    y = point.y,
                    val = grid[point.x + 1][point.y]
                };
            }

            if (point.y < grid[point.x].Length - 1 &&
                grid[point.x][point.y + 1] != -1 &&
                visited[point.x][point.y + 1] == false)
            {
                yield return new Point
                {
                    x = point.x,
                    y = point.y + 1,
                    val = grid[point.x][point.y + 1]
                };
            }

            if (point.x > 0 &&
                grid[point.x - 1][point.y] != -1 &&
                visited[point.x - 1][point.y] == false)
            {
                yield return new Point
                {
                    x = point.x - 1,
                    y = point.y,
                    val = grid[point.x - 1][point.y]
                };
            }

            if (point.y > 0 &&
                grid[point.x][point.y - 1] != -1 &&
                visited[point.x][point.y - 1] == false)
            {
                yield return new Point
                {
                    x = point.x,
                    y = point.y - 1,
                    val = grid[point.x][point.y - 1]
                };
            }

            yield break;
        }

        class Point
        {
            public int val;
            public int x;
            public int y;

            public override string ToString()
            {
                return $"{x},{y}={val}";
            }
        }
    }
}
