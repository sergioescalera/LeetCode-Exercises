using LeetCode.Attributes;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public static class TwoSum
    {
        public static void Run()
        {
            var numbers = new[] { 3, 2, 4/*2, 7, 11, 11, 15*/ };
            var target = 6;//22;

            //var solution = FindBruteForce(numbers, target);
            var solution = FindDictionary(numbers, target);

            Console.WriteLine($"Two Sum Result: {String.Join(", ", solution)}");
        }

        private static Int32[] FindBruteForce(Int32[] nums, Int32 target)
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

        private static Int32[] FindDictionary(Int32[] nums, Int32 target)
        {
            var dictionary = new Dictionary<Int32, Int32>();

            for (int i = 0; i < nums.Length; i++)
            {
                var current = nums[i];
                var diff = target - current;

                if (dictionary.ContainsKey(diff))
                    return new[] { dictionary[diff], i };

                if (!dictionary.ContainsKey(current))
                    dictionary.Add(current, i);
            }

            return new int[0];
        }
    }
}
