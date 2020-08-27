using LeetCode.Attributes;
using System;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class FindRightIntervalExercise
    {
        public static void Run()
        {
            var ex = new FindRightIntervalExercise();

            var intervals = new[]
            {
                new [] { 3, 4 },
                new [] { 2, 3 },
                new [] { 1, 2 },
                new [] { 0, 0 },
                new [] { -1, -1 },
                new [] { -4, -3 },
                new [] { 5, 10 }
            };

            var right = ex.FindRightInterval(intervals);
        }

        /// <summary>
        /// Given a set of intervals, for each of the interval i, check if there exists an interval j whose start point is bigger than or equal to the end point of the interval i, which can be called that j is on the "right" of i.
        /// 
        /// For any interval i, you need to store the minimum interval j's index, which means that the interval j has the minimum start point to build the "right" relationship for interval i. If the interval j doesn't exist, store -1 for the interval i.Finally, you need output the stored value of each interval as an array.
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[] FindRightInterval(int[][] intervals)
        {
            if (intervals == null)
            {
                throw new ArgumentNullException(nameof(intervals));
            }

            if (intervals.Length == 0)
            {
                return new int[0];
            }

            if (intervals.Length == 1)
            {
                return new[] { -1 };
            }

            var sorted = intervals
                .Select((o, i) => new Interval
                {
                    index = i,
                    start = o[0],
                    end = o[1]
                })
                .OrderBy(o => o.start)
                .ToArray();

            var results = new int[intervals.Length];
            
            for (int i = 0; i < sorted.Length; i++)
            {
                var interval = sorted[i];

                if (i == sorted.Length - 1)
                {
                    results[interval.index] = -1;     
                }
                else
                {
                    var next = FindNext(sorted, i);

                    results[interval.index] = next == null ? -1 : next.index;
                }
            }

            return results;
        }

        private Interval FindNext(Interval[] intervals, int i)
        {
            for (int j = i + 1; j < intervals.Length; j++)
            {
                var next = intervals[j];

                if (next.start >= intervals[i].end)
                {
                    return next;
                }
            }

            return null;
        }

        class Interval
        {
            internal int index;
            internal int start;
            internal int end;
        }
    }
}
