using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class SnakesAndLaddersSolution
    {
        public int SnakesAndLadders(int[][] board)
        {

            if (board == null)
            {
                return -1;
            }

            var n = board.Length;
            var start = 1;
            var end = n * n;

            var levels = new int[end + 1];
            var dice = 6;

            var queue = new Queue<int>();

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                var level = levels[node];

                if (node == end)
                {
                    return level;
                }

                var adjacents = Enumerable.Range(node + 1, dice).Where(o => o <= end);

                foreach (var a in adjacents)
                {

                    var i = n - (a - 1) / n - 1;

                    var j = (a - 1) / n % 2 == 0 ? (a - 1) % n : n - (a - 1) % n - 1;

                    if (board[i][j] < 0)
                    {

                        if (levels[a] > 0 || a == start)
                        {
                            continue;
                        }

                        levels[a] = level + 1;
                        queue.Enqueue(a);

                    }
                    else
                    {

                        var jump = board[i][j];

                        if (levels[jump] > 0 || jump == start)
                        {
                            continue;
                        }

                        levels[jump] = level + 1;
                        queue.Enqueue(jump);
                    }
                }
            }

            return -1;
        }
    }
}
