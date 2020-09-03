using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] nums)
        {
            if (nums == null)
            {
                return 0;
            }

            if (nums.Length == 0)
            {
                return 0;
            }

            var set = new HashSet<int>(nums);
            
            var longest = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                var n = nums[i];
                var count = 1;

                if (set.Contains(n - 1))
                {
                    continue;
                }

                if (set.Contains(n) == false)
                {
                    continue;
                }

                while (set.Contains(n + count))
                {
                    count++;
                }

                longest = Math.Max(count, longest);
            }

            return longest;
        }
    }
}
