using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ThreeSumExercise
    {
        public static void Run()
        {
            var exercise = new ThreeSumExercise();

            do
            {
                var nums = exercise.ReadNums();

                if (nums == null)
                    break;

                var result = exercise.ThreeSum(nums);

                foreach (var item in result)
                {
                    Console.WriteLine(String.Join(",", item));
                }

            } while (true);
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums == null)
                return null;

            if (nums.Length < 3)
                return new int[0][];

            var dic = new Dictionary<string, IList<int>>();

            var distinct = nums.Distinct().ToArray();

            if (distinct.Length == 1)
            {
                return distinct[0] == 0 ? new[] { new [] { 0, 0, 0 } } : new IList<int>[0];
            }

            for (int i = 0; i < nums.Length - 2; i++)
            {
                var val = nums[i];
                var target = -val;

                var twosum = TwoSum(nums, i + 1, target);

                foreach (var tuple in twosum)
                {
                    var triple = new[] { val, tuple[0], tuple[1] }.OrderBy(o => o).ToArray();

                    var key = String.Join(",", triple);

                    if (dic.ContainsKey(key) == false)
                    {
                        dic.Add(key, triple);
                    }
                }
            }

            return dic.Values.ToList();
        }

        private IEnumerable<IList<int>> TwoSum(int[] nums, int index, int target)
        {
            var dic = new Dictionary<String, IList<int>>();
            var dictionary = new Dictionary<int, int>();

            for (int i = index; i < nums.Length; i++)
            {
                var current = nums[i];
                var diff = target - current;

                if (dictionary.ContainsKey(diff))
                {
                    var duple = new[] { diff, current }.OrderBy(o => o).ToArray();
                    var k = String.Join(",", duple);
                    
                    if (dic.ContainsKey(k) == false)
                        dic.Add(k, duple);
                }

                else if (dictionary.ContainsKey(current) == false)
                    dictionary.Add(current, i);
            }

            return dic.Values;
        }
    }
}
