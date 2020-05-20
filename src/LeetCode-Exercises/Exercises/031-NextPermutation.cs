using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class NextPermutationExercise
    {
        public static void Run()
        {
            var exercise = new NextPermutationExercise();

            do
            {
                var nums = exercise.ReadNums();

                if (nums == null)
                    break;

                exercise.NextPermutation(nums);

                Console.WriteLine(String.Join(", ", nums));

            } while (true);
        }

        public void NextPermutation(int[] nums)
        {
            if (nums == null)
            {
                return;
            }

            var found = FindPosition(nums);

            if (found < 0)
            {
                Reverse(nums);
            }
            else
            {
                var next = found + 1;

                for (int i = found + 2; i < nums.Length; i++)
                {
                    if (nums[i] > nums[found] && nums[i] < nums[next])
                    {
                        next = i;
                    }
                }

                var temp = nums[found];

                nums[found] = nums[next];
                nums[next] = temp;

                Sort(nums, found + 1);
            }
        }

        private int FindPosition(int[] nums)
        {
            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i] > nums[i - 1])
                {
                    return i - 1;
                }
            }

            return -1;
        }

        private void Sort(int[] nums, int start)
        {
            for (int i = start; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        var temp = nums[j];

                        nums[j] = nums[i];
                        nums[i] = temp;
                    }
                }
            }
        }

        private void Reverse(int[] nums)
        {
            var m = nums.Length / 2;

            for (int i = 0; i < m; i++)
            {
                var t = nums[i];

                nums[i] = nums[nums.Length - i - 1];
                nums[nums.Length - i - 1] = t;
            }
        }
    }
}
