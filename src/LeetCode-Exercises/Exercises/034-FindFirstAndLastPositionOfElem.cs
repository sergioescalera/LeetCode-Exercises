using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class FindFirstAndLastPositionOfElem
    {
        public static void Run()
        {
            while (true)
            {
                var exercise = new FindFirstAndLastPositionOfElem();
                var nums = exercise.ReadNums();
                var target = exercise.ReadNum();


                if (nums == null || target == null)
                    break;

                var result = exercise.SearchRange(nums, target.Value);

                Console.WriteLine("Results:");
                Console.WriteLine("{0}, {1}", result.FirstOrDefault(), result.LastOrDefault());
                Console.WriteLine();
            }
        }  

        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return new[] { -1, -1 };

            var start = FindStart(nums, target);

            if (start < 0)
            {
                return new[] { -1, -1 };
            }

            var end = FindEnd(nums, target, start);

            return new[] { start, end };
        }

        private int FindStart(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                if (nums[start] == target)
                    return start;

                var middle = start + (end - start) / 2;

                if (nums[middle] >= target)
                {
                    end = middle;
                    start++;
                }
                else
                {
                    start = middle + 1;
                }
            }

            return -1;
        }

        private int FindEnd(int[] nums, int target, int start)
        {
            int end = nums.Length - 1;

            while (start <= end)
            {
                if (nums[end] == target)
                    return end;

                var middle = start + (end - start) / 2;

                if (nums[middle] <= target)
                {
                    start = middle;
                    end--;
                }
                else
                {
                    end = middle - 1;
                }
            }

            return -1;
        }
    }
}
