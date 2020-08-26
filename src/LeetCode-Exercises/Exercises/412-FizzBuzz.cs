using LeetCode.Extensions;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    public class FizzBuzzExercise
    {
        public static void Run()
        {
            var ex = new FizzBuzzExercise();

            do
            {
                var n = ex.ReadNum("Enter n");

                if (n == null)
                    break;

                var r = ex.FizzBuzz(n.Value);

                Console.WriteLine(String.Join(", ", r));

            } while (true);
        }

        /// <summary>
        /// Write a program that outputs the string representation of numbers from 1 to n.
        /// But for multiples of three it should output “Fizz” instead of the number and for the multiples of five output “Buzz”.
        /// For numbers which are multiples of both three and five output “FizzBuzz”.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> FizzBuzz(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            var result = new string[n];

            for (int i = 1; i <= n; i++)
            {
                var index = i - 1;

                if (i % 5 == 0 && i % 3 == 0)
                {
                    result[index] = "FizzBuzz";
                }
                else if (i % 5 == 0)
                {
                    result[index] = "Buzz";
                }
                else if (i % 3 == 0)
                {
                    result[index] = "Fizz";
                }
                else
                {
                    result[index] = i.ToString();
                }
            }

            return result;
        }
    }
}
