using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class HIndexExercise
    {
        public static void Run()
        {
            var ex = new HIndexExercise();

            do
            {
                var nums = ex.ReadNums("Enter citations");

                if (nums == null)
                {
                    break;
                }

                var h = ex.HIndex(nums);

                Console.WriteLine("H-Index is {0}", h);

            } while (true);
        }

        /// <summary>
        /// The h-index is defined as the maximum value of h such that the given author/journal has 
        /// published h papers that have each been cited at least h times.
        /// </summary>
        /// <param name="citations"></param>
        /// <returns></returns>
        public int HIndex(int[] citations)
        {
            if (citations == null)
            {
                throw new ArgumentNullException();
            }

            if (citations.Length == 0)
            {
                return 0;
            }
            
            var sorted = citations
                .Where(o => o > 0)
                .OrderBy(o => o)
                .ToArray();

            var hIndex = sorted.Length;

            while (hIndex > 0)
            {
                if (sorted[sorted.Length - hIndex] >= hIndex)
                {
                    break;
                }

                hIndex--;
            }

            return hIndex;
        }
    }
}
