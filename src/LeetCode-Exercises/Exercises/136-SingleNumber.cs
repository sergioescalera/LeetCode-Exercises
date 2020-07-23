using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SingleNumberI
    {
        public int SingleNumberHash(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));

            if (nums.Length == 0)
                throw new ArgumentException();

            if (nums.Length <= 1)
                return nums[0];

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

            if (set.Count != 1)
                throw new ArgumentException();

            return set.Single();
        }

        public int SingleNumber(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));

            if (nums.Length == 0)
                throw new ArgumentException();

            var n = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                n ^= nums[i];
            }

            return n;
        }
    }
}
