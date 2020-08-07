using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class FindAllDuplicatesInArray
    {
        public static void Run()
        {
            var ex = new FindAllDuplicatesInArray();

            do
            {
                var nums = ex.ReadNums();

                if (nums == null)
                    break;

                var dupes = ex.FindDuplicates(nums);

                Console.WriteLine(String.Join(", ", dupes));
                Console.WriteLine();

            } while (true);
        }

        public IList<int> FindDuplicates(int[] nums)
        {
            if (nums == null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            var bits = new Boolean?[nums.Length];

            var dupes = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var n = nums[i];
                var index = n - 1;

                if (n <= 0 || n > nums.Length)
                {
                    throw new ArgumentException();
                }

                if (bits[index] == null)
                {
                    bits[index] = false;
                }
                else if (bits[index] == false)
                {
                    bits[index] = true;

                    dupes.Add(n);
                }
            }

            return dupes;
        }

        public IList<int> FindDuplicates2(int[] nums)
        {
            if (nums == null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            var bits = 0;

            var dupes = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var n = nums[i];
                
                if (n <= 0 || n > nums.Length)
                {
                    throw new ArgumentException();
                }

                if (bits ^ n == bits)
                {

                }
            }

            return dupes;
        }
    }
}
