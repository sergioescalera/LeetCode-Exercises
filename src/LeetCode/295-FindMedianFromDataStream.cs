using LeetCode.Data;
using System.Collections.Generic;

namespace LeetCode
{
    public class MedianFinder
    {
        private readonly SortedSet<Value> right;
        private readonly SortedSet<Value> left;

        private int count = 0;
        private double? median = null;

        public MedianFinder()
        {

            right = new SortedSet<Value>(new ValueComparer());
            left = new SortedSet<Value>(new ValueComparer());
        }

        public void AddNum(int num)
        {
            var val = new Value(count, num);

            if (count == 0)
            {
                right.Add(val);

                median = num;
            }

            else if (left.Count == right.Count)
            {
                if (num < right.Min.val)
                {
                    left.Add(val);
                    median = left.Max.val;
                }
                else
                {
                    right.Add(val);
                    median = right.Min.val;
                }
            }

            else if (left.Count > right.Count)
            {
                if (num < median)
                {
                    right.Add(left.Max);

                    left.Remove(left.Max);

                    left.Add(val);
                }
                else
                {
                    right.Add(val);
                }

                median = (right.Min.val + left.Max.val) / 2.0;
            }

            else
            {
                if (num < median)
                {
                    left.Add(val);
                }
                else
                {
                    left.Add(right.Min);

                    right.Remove(right.Min);

                    right.Add(val);
                }

                median = (right.Min.val + left.Max.val) / 2.0;
            }

            count++;
        }

        public double FindMedian()
        {
            return median.Value;
        }
    }
}
