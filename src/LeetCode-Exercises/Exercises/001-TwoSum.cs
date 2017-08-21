using LeetCode.Attributes;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public static class TwoSum
    {
        public static void Run()
        {
            var numbers = new[] { 2, 7, 11, 15 };
            var target = 22;

            var solution = FindPair(numbers, target);

            Console.WriteLine($"Two Sum Result: {String.Join(", ", solution)}");
        }

        private static Int32[] FindPair(Int32[] nums, Int32 target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return new[] { i, j };
                }
            }

            return new int[0];
        }
    }
}
