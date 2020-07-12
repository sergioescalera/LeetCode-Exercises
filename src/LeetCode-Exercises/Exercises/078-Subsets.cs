using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SubsetsExercise
    {
        public static void Run()
        {
            var exercise = new SubsetsExercise();

            do
            {
                var nums = exercise.ReadNums();

                if (nums == null)
                    break;

                var subsets = exercise.Subsets(nums);

                foreach (var subset in subsets)
                {
                    Console.Write("[" + String.Join(",", subset) + "]");
                    Console.Write(" ");
                }

                Console.WriteLine();

            } while (true);
        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            if (nums == null)
                return null;

            var result = new List<IList<int>>();
            
            for (int i = 0; i <= nums.Length; i++)
            {
                result.AddRange(Subsets(nums, i));
            }

            return result;
        }

        private IList<List<int>> Subsets(IList<int> nums, int length)
        {
            if (length == 0)
                return new[] { new List<int>() };

            if (length == nums.Count)
                return new[] { nums.ToList() };

            if (length == 1)
            {
                return nums
                    .Select(n => new List<int> { n })
                    .ToList();
            }

            var result = new List<List<int>>();

            var values = nums.ToList();

            for (int i = nums.Count - 1; i >= 0; i--)
            {
                var n = nums[i];

                values.RemoveAt(values.Count - 1);

                var subsets = Subsets(values, length - 1);

                foreach (var subset in subsets)
                {
                    subset.Add(n);

                    result.Add(subset);
                }
            }

            return result;
        }
    }
}
