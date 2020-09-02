using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LeetCode
{
    public class ContainsDuplicateIII
    {
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (nums == null)
            {
                return false;
            }

            if (nums.Length <= 1)
            {
                return false;
            }

            if (k <= 0)
            {
                return false;
            }

            if (t < 0)
            {
                return false;
            }

            var intervals = new SortedList<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var val = nums[i];

                if (i > k)
                {
                    var removeVal = nums[i - k - 1];

                    var count = intervals[removeVal];

                    if (count == 1)
                    {
                        intervals.Remove(removeVal);
                    }
                    else
                    {
                        --intervals[removeVal];
                    }
                }

                if (FindInInterval(intervals, val, t, 0, intervals.Keys.Count - 1))
                {
                    return true;
                }

                if (intervals.ContainsKey(val))
                {
                    intervals[val]++;
                }
                else
                {
                    intervals.Add(val, 1);
                }
            }

            return false;
        }

        private bool FindInInterval(
            SortedList<int, int> intervals,
            int val,
            int distance,
            int start,
            int end)
        {
            if (start > end)
            {
                return false;
            }

            var startValue = intervals.Keys[start];

            if (Math.Abs(startValue - (long)val) <= distance)
                return true;

            var endValue = intervals.Keys[end];

            if (Math.Abs(endValue - (long)val) <= distance)
                return true;

            var middle = start + (end - start) / 2;

            if (middle == start)
                return false;

            if (intervals.Keys[middle] < val)
            {
                return FindInInterval(intervals, val, distance, middle, end);
            }
            else
            {
                return FindInInterval(intervals, val, distance, start, middle);
            }
        }

        public bool ContainsNearbyAlmostDuplicateNxK(int[] nums, int k, int t)
        {
            if (nums == null)
            {
                return false;
            }

            if (nums.Length <= 1)
            {
                return false;
            }

            if (k <= 0)
            {
                return false;
            }

            if (t < 0)
            {
                return false;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j <= i + k && j < nums.Length; j++)
                {
                    var diff = Math.Abs((long)nums[i] - (long)nums[j]);

                    if (diff <= t)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
