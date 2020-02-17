using LeetCode.Attributes;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ReverseInteger
    {
        public static void Run()
        {
            var exercise = new ReverseInteger();

            var solution123 = exercise.Reverse(123);
            var solution9 = exercise.Reverse(9);
            var solution120 = exercise.Reverse(120);
            var solutionm120 = exercise.Reverse(-120);

            Console.WriteLine($"Reverse Integer of 123: {solution123}");
            Console.WriteLine($"Reverse Integer of 9: {solution9}");
            Console.WriteLine($"Reverse Integer of 120: {solution120}");
            Console.WriteLine($"Reverse Integer of -120: {solutionm120}");
        }

        public int Reverse(int x)
        {
            if (x == 0)
            {
                return 0;
            }

            var r = x < 0 ? -ReversePositive(-x, out int d) : ReversePositive(x, out int e);

            if (Int32.MinValue <= r && r <= Int32.MaxValue)
            {
                return (Int32)r;
            }

            return 0;
        }

        private double ReversePositive(int x, out int d)
        {
            d = 0;

            if (x < 10)
            {
                return x;
            }

            var a = x / 10;
            var r = x % 10;

            var b = ReversePositive(a, out var c);

            d = c + 1;

            return b + Math.Pow(10, d) * r;
        }
    }
}
