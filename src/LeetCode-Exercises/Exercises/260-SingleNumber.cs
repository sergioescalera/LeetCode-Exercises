using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SingleNumberIII
    {
        public int[] SingleNumber(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));

            if (nums.Length == 0)
                throw new ArgumentException();

            if (nums.Length <= 2)
                return nums;

            var set = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var n = nums[i];

                if (set.Contains(n))
                {
                    set.Remove(n);
                }
                else
                {
                    set.Add(n);
                }
            }

            return set.ToArray();
        }
    }
}
