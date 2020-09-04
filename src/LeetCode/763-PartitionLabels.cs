using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LeetCode
{
    public class PartitionLabelsSolution
    {
        public IList<int> PartitionLabels(string str)
        {
            if (str == null || str.Length == 0)
            {
                return new int[0];
            }

            var partitions = new List<int>(str.Length);

            var intervals = new SortedDictionary<char, Interval>();

            for (int i = 0; i < str.Length; i++)
            {
                var x = str[i];

                if (intervals.ContainsKey(x))
                {
                    intervals[x].end = i;
                }
                else 
                {
                    intervals.Add(x, new Interval
                    {
                        start = i,
                        end = i
                    });
                }
            }

            if (intervals.Count == 1)
            {
                return new[] { str.Length };
            }

            if (intervals.Count == str.Length)
            {
                return str.Select(o => 1).ToArray();
            }

            var set = new SortedSet<Interval>(intervals.Values);

            while (set.Count > 0)
            {
                var current = set.Min;

                set.Remove(current);

                while (set.Count > 0 && set.Min.start < current.end)
                {
                    var next = set.Min;

                    set.Remove(next);

                    current.end = Math.Max(next.end, current.end);
                }

                partitions.Add(current.end - current.start + 1);
            }

            return partitions;
        }

        [DebuggerDisplay("[{start} - {end}]")]
        class Interval : IComparable<Interval>
        {
            public int start;
            public int end;

            public override int GetHashCode()
            {
                return start.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                return obj is Interval i && i.start == start && i.end == end;
            }

            public int CompareTo(Interval other)
            {
                return start - other.start;
            }
        }

        class IntervalComparer : IComparer<Interval>
        {
            public int Compare(Interval x, Interval y)
            {
                return x.start - y.start;
            }
        }
    }
}
