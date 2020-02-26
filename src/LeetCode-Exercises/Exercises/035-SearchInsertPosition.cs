using LeetCode.Attributes;
using LeetCode.Extensions;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SearchInsertPosition
    {
        public static void Run()
        {
            var exercise = new SearchInsertPosition();

            do
            {
                var nums = exercise.ReadNums();
                var target = exercise.ReadNum();

                if (nums == null || target == null)
                {
                    return;
                }

                var solution = exercise.SearchInsert(nums, target.Value, 0, nums.Length - 1);

                Console.WriteLine("Position is {0}", solution);
                Console.WriteLine();

            } while (true);
        }

        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null)
            {
                return -1;
            }

            if (nums.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var n = nums[i];

                if (n >= target)
                {
                    return i;
                }
            }

            return nums.Length;
        }

        public int SearchInsert(int[] nums, int target, int start, int end)
        {
            if (start >= end)
            {
                return nums[start] >= target ? start : start + 1;
            }

            var middle = (start + end) / 2 + 1;

            var n = nums[middle];

            if (n >= target)
            {
                return SearchInsert(nums, target, start, middle - 1);
            }

            return SearchInsert(nums, target, middle, end);
        }
    }
}
