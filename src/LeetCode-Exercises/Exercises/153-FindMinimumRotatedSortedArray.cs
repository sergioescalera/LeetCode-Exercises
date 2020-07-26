using LeetCode.Attributes;
using LeetCode.Extensions;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class FindMinimumRotatedSortedArray
    {
        public static void Run()
        {
            var ex = new FindMinimumRotatedSortedArrayII();

            do
            {
                var nums = ex.ReadNums();

                if (nums == null)
                    break;

                var min = ex.FindMin(nums);

                Console.WriteLine("Min is {0}", min);
                Console.WriteLine();


            } while (true);
        }

        public int FindMin(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException();

            if (nums.Length == 0)
                throw new ArgumentException();

            return FindMin(nums, 0, nums.Length - 1);
        }

        private int FindMin(int[] nums, int start, int end)
        {
            if (start >= end)
            {
                return nums[start];
            }

            if (start == end - 1)
            {
                return nums[start] < nums[end] ? nums[start] : nums[end];
            }

            if (nums[end] > nums[start])
            {
                return nums[start];
            }

            var middle = start + (end - start) / 2;

            if (nums[start] == nums[middle] &&
                nums[middle] == nums[end])
            {
                return Math.Min(
                    FindMin(nums, start, middle - 1),
                    FindMin(nums, middle, end - 1));
            }

            if (nums[middle] >= nums[start])
            {
                return FindMin(nums, middle, end);
            }
            else
            {
                return FindMin(nums, start + 1, middle);
            }
        }
    }
}
