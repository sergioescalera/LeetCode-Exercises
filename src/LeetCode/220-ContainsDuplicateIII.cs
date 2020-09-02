using System;
using System.Collections.Generic;
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
