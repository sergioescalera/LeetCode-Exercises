using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class RemoveDuplicatesSortedArray
    {
        public static void Run()
        {
            var exercise = new RemoveDuplicatesSortedArray();

            var array = new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4, 7, 8, 9, 10, 10, 11 };

            var len = exercise.RemoveDuplicates(array);

            var result = array.Take(len).ToArray();

            Console.WriteLine("{0}={1}", "[0, 0, 1, 1, 1, 2, 2, 3, 3, 4, 7, 8, 9, 10, 10, 11]", $"[{String.Join(", ", result)}]");
        }

        public Int32 RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return 1;

            var count = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                var a = nums[count - 1];
                var b = nums[i];

                if (a != b)
                {
                    nums[count] = b;

                    count++;
                }
            }

            return count;
        }
    }
}
