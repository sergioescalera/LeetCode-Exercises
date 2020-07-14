using LeetCode.Attributes;
using LeetCode.Extensions;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SortColorsExercise
    {
        public static void Run()
        {
            var exercise = new SortColorsExercise();

            do
            {
                var nums = exercise.ReadNums();

                if (nums == null)
                    break;

                exercise.SortColors(nums);

                Console.WriteLine(String.Join(", ", nums));
                Console.WriteLine();

            } while (true);
        }

        public void SortColors(int[] nums)
        {
            if (nums == null)
            {
                return;
            }

            if (nums.Length < 2)
            {
                return;
            }

            var start = 0;
            var end = nums.Length - 1;

            for (int i = 0; i <= end;)
            {
                if (nums[i] == 0)
                {
                    nums[i] = nums[start];
                    nums[start] = 0;

                    i++;
                    start++;
                }
                else if (nums[i] == 2)
                {
                    nums[i] = nums[end];
                    nums[end] = 2;

                    end--;
                } else
                {
                    i++;
                }
            }
        }
    }
}
