using LeetCode.Attributes;
using LeetCode.Extensions;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SearchRotatedSortedArray
    {
        public static void Run()
        {
            var exercise = new SearchRotatedSortedArray();

            do
            {
                var nums = exercise.ReadNums();
                var target = exercise.ReadNum();

                if (nums == null || target == null)
                    break;

                var result = exercise.Search(nums, target.Value);

                Console.WriteLine("Result={0}", result);
                Console.WriteLine();

            } while (true);
        }

        // nums = [4,5,6,7,0,1,2,3], target = 0
        // nums = [6,7,0,1,2,3,4,5], target = 0
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            return Search(nums, target, 0, nums.Length - 1);
        }

        private int Search(int[] nums, int target, int start, int end)
        {
            var first = nums[start];
            var last = nums[end];

            if (first == target)
            {
                return start;
            }

            if (last == target)
            {
                return end;
            }
            
            if (start >= end - 1)
            {
                return -1;
            }

            var middle = (start + end) / 2;
            var center = nums[middle];
            
            if (first <= target && target <= center)
            {
                return Search(nums, target, start + 1, middle);
            }

            if (center <= target && target <= last)
            {
                return Search(nums, target, middle, end - 1);
            }

            if (first < center)
            {
                return Search(nums, target, middle, end - 1);
            }

            if (center < last)
            {
                return Search(nums, target, start + 1, middle);
            }

            return -1;
        }
    }
}
