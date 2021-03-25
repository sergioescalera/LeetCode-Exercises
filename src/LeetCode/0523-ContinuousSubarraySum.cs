using System;

namespace LeetCode
{
    public class ContinuousSubarraySumSolution
    {
        public bool CheckSubarraySum(int[] nums, int k)
        {

            if (nums == null)
            {
                return false;
            }

            if (nums.Length == 0)
            {
                return false;
            }

            if (nums.Length == 1)
            {
                return nums[0] == k;
            }

            var start = 0;
            var end = 0;
            var sum = 0L;

            while (end < nums.Length)
            {

                sum += nums[end];

                if (sum == k)
                {
                    return true;
                }

                if (sum < k)
                {

                    end++;

                }
                else
                {

                    while (start < end && sum >= k)
                    {

                        if (sum == k)
                        {
                            return true;
                        }

                        sum -= nums[start];

                        start++;
                    }

                    if (sum == k)
                    {
                        return true;
                    }

                    if (start == end && sum > k)
                    {
                        sum -= nums[start];

                        start++;
                        end++;
                    }
                }
            }

            return false;
        }
    }
}
