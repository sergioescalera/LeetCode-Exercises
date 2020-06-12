using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            if (intervals == null)
            {
                throw new ArgumentNullException(nameof(intervals));
            }

            if (intervals.Length == 0)
            {
                return new int[0][];
            }

            var sorted = intervals
                .OrderBy((o) =>
                {
                    if (o.Length.Equals(2) == false)
                    {
                        throw new ArgumentException(nameof(intervals));
                    }

                    if (o[0] > o[1])
                    {
                        throw new ArgumentException(nameof(intervals));
                    }

                    return o[0];
                })
                .ToArray();

            var list = new List<int[]>(sorted.Length);

            var current = sorted[0];

            for (int i = 1; i < sorted.Length; i++)
            {
                var interval = sorted[i];

                if (interval[0] > current[1])
                {
                    list.Add(current);

                    current = interval;
                }
                else
                {
                    current = new[] { current[0], Math.Max(interval[1], current[1]) };
                }
            }

            list.Add(current);

            return list.ToArray();
        }
    }
}
