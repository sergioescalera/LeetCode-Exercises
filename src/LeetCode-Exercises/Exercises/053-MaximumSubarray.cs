using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class MaximumSubarray
    {
        public static void Run()
        {
            var exercise = new MaximumSubarray();

            do
            {
                var nums = exercise.ReadNums();
                
                if (nums == null)
                {
                    return;
                }

                var solution = exercise.MaxSubArray(nums);

                Console.WriteLine("Sum is {0}", solution);
                Console.WriteLine();

            } while (true);
        }

        public int MaxSubArray(int[] nums)
        {
            var tuple = MaxSubArray(nums, 0);

            return Math.Max(
                tuple.Item1 ?? int.MinValue, 
                tuple.Item2 ?? int.MinValue);
        }

        private Tuple<int?, int?> MaxSubArray(int[] nums, int start)
        {
            if (nums == null)
                return Tuple.Create(default(int?), default(int?));

            if (start >= nums.Length)
                return Tuple.Create(default(int?), default(int?));

            var n = (int?)nums[start];

            var t = MaxSubArray(nums, start + 1);

            if (t.Item1 == null && t.Item2 == null)
                return Tuple.Create(n, default(int?));

            var a = Math.Max(n.Value, t.Item1.Value + n.Value);

            var b = t.Item2 == null ? t.Item1 : Math.Max(t.Item1.Value, t.Item2.Value);

            return Tuple.Create((int?)a, (int?)b);
        }
    }
}
