using LeetCode.Attributes;
using LeetCode.Extensions;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class FindMinimumRotatedSortedArrayII
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

        /// <summary>
        /// Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
        /// (i.e.,  [0, 1, 2, 4, 5, 6, 7] might become[4, 5, 6, 7, 0, 1, 2]).
        /// Find the minimum element.
        /// The array may contain duplicates.
        /// 
        /// Example 1:
        /// Input: [1,3,5]
        /// Output: 1
        /// 
        /// Example 2:
        /// Input: [2,0,1,1,1]
        /// Output: 0
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
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
