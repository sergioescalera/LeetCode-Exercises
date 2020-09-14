using System;
using System.Linq;

namespace LeetCode
{
    public class HouseRobber
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

            Rob(nums, 0, totals);

            return totals[0];
        }

        public void Rob(int[] nums, int index, int[] totals)
        {

            if (index == nums.Length - 1)
            {
                totals[index] = nums[index];
            }

            else if (index == nums.Length - 2)
            {
                totals[index + 1] = nums[index + 1];
                totals[index] = Math.Max(nums[index], nums[index + 1]);
            }

            else
            {
                Rob(nums, index + 1, totals);
                totals[index] = Math.Max(totals[index + 1], totals[index + 2] + nums[index]);
            }
        }
    }
}
