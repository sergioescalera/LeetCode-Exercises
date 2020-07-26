using LeetCode.Attributes;
using LeetCode.Extensions;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class AddDigitsExercise
    {
        public static void Run()
        {
            var ex = new AddDigitsExercise();

            do
            {
                var n = ex.ReadNum();

                if (n == null)
                    break;

                var sum = ex.AddDigits(n.Value);

                Console.WriteLine(sum);

                Console.ReadLine();

            } while (true);
        }

        public int AddDigits(int num)
        {
            if (num < 10)
            {
                return num;
            }

            do
            {
                num = GetDigitsSum(num);

            } while (num >= 10);

            return num;
        }

        private int GetDigitsSum(int num)
        {
            var sum = 0;

            while (num > 0)
            {
                sum += num % 10;

                num /= 10;
            }

            return sum;
        }
    }
}
