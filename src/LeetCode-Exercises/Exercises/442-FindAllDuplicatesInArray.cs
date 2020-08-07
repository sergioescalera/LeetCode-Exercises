using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.CodeDom;
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

        public IList<int> FindDuplicates2(int[] nums)
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

        public IList<int> FindDuplicates(int[] nums)
        {

            if (nums == null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            Console.WriteLine(nums.Length);

            var dupes = new List<int>();
            var count = nums.Length;
            var bits = new int[count / 32 + (count % 32 == 0 ? 0 : 1)];

            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];

                if (value <= 0 || value > nums.Length)
                {
                    throw new ArgumentException();
                }

                if (value / 32 < 0 || value / 32 >= bits.Length)
                {
                    Console.WriteLine(value);
                }

                var x = (value - 1) / 32;
                var n = bits[x];
                var y = (value - 1) % 32;

                if (n.GetBit(y))
                {
                    dupes.Add(value);
                }
                else
                {
                    bits[x] = n.SetBit(y);
                }
            }

            return dupes;
        }
    }
}
