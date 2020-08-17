using LeetCode.Attributes;
using LeetCode.Extensions;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class DistributeCandiesToPeople
    {
        public static void Run()
        {
            var ex = new DistributeCandiesToPeople();

            do
            {
                var candies = ex.ReadNum("Enter candies");

                if (candies == null)
                    break;

                var people = ex.ReadNum("Enter people");

                if (people == null)
                    break;

                var distribution = ex.DistributeCandies(candies.Value, people.Value);

                Console.WriteLine(String.Join(", ", distribution));
                Console.WriteLine();

            } while (true);
        }

        /*
         * 

Input: candies = 10, num_people = 3
Output: [5,2,3]
Explanation: 
On the first turn, ans[0] += 1, and the array is [1,0,0].
On the second turn, ans[1] += 2, and the array is [1,2,0].
On the third turn, ans[2] += 3, and the array is [1,2,3].
On the fourth turn, ans[0] += 4, and the final array is [5,2,3].

         *
         */
        public int[] DistributeCandies(int candies, int num_people)
        {
            if (candies <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(candies));
            }

            if (num_people <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(num_people));
            }

            var n = num_people;
            var array = new int[n];
            var k = 0;

            while (candies > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    k++;

                    if (k <= candies)
                    {
                        array[i] += k;

                        candies -= k;
                    }
                    else
                    {
                        array[i] += candies;

                        candies = 0;

                        break;
                    }
                }
            }

            return array;
        }
    }
}
