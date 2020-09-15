using System;
using System.Linq;

namespace LeetCode
{
    public class HouseRobber2
    {
        public int Rob(int[] nums)
        {

            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length <= 2)
            {
                return nums.Max();
            }

            var totals = new int[nums.Length];

            Rob(nums, 0, nums.Length - 2, totals);

            Rob(nums, 1, nums.Length - 1, totals);

            return Math.Max(totals[0], totals[1]);
        }

        public void Rob(int[] nums, int index, int end, int[] totals)
        {
            if (index == end)
            {
                totals[index] = nums[index];
            }

            else if (index == end - 1)
            {
                totals[index + 1] = nums[index + 1];
                totals[index] = Math.Max(nums[index], nums[index + 1]);
            }

            else
            {
                Rob(nums, index + 1, end, totals);
                totals[index] = Math.Max(totals[index + 1], totals[index + 2] + nums[index]);
            }
        }
    }
}
