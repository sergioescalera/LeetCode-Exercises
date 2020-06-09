using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class Permutations
    {
        public static void Run()
        {
            var exercise = new Permutations();

            do
            {
                var nums = exercise.ReadNums();

                if (nums == null)
                    break;

                var permutations = exercise.Permute(nums);

                Console.WriteLine();

                foreach (var permutation in permutations)
                {
                    Console.WriteLine(String.Join(",", permutation));
                }

                Console.WriteLine();

            } while (true);
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            if (nums == null)
                return null;

            return Permute(nums, 0);
        }

        private IList<IList<int>> Permute(int[] nums, int index)
        {
            if (index >= nums.Length)
                return new IList<int>[] { new int[0] };

            var permutations = Permute(nums, index + 1);
            var results = new List<IList<int>>();

            foreach (var permutation in permutations)
            {
                for (int i = 0; i <= permutation.Count; i++)
                {
                    var result = new List<int>(permutation);
                    
                    if (i == permutation.Count)
                    {
                        result.Add(nums[index]);
                    }
                    else
                    {
                        result.Insert(i, nums[index]);
                    }

                    results.Add(result);
                }
            }

            return results;
        }
    }
}
