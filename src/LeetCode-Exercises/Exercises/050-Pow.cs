using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.IO.Pipes;

namespace LeetCode.Exercises
{
    [Exercise]
    public class Pow
    {
        public static void Run()
        {
            var exercise = new Pow();

            do
            {
                Console.ForegroundColor = ConsoleColor.White;

                var x = exercise.ReadDouble();
                var n = exercise.ReadNum();

                if (x == null || n == null)
                    break;

                var pow = exercise.MyPow(x.Value, n.Value);

                var expected = Math.Pow(x.Value, n.Value);

                Console.ForegroundColor = pow == expected ? ConsoleColor.Green : ConsoleColor.Red;

                Console.WriteLine("Actual={0}, Expected={1}", pow, expected);
                Console.WriteLine();

            } while (true);

            Console.ForegroundColor = ConsoleColor.White;
        }

        public double MyPow(double x, int n)
        {
            if (x <= -100.0 || x >= 100.0)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            if (n == 0)
            {
                return 1;
            }

            if (n == int.MinValue)
            {
                return 1 / (MyPow(x, int.MaxValue) * x);
            }

            if (n < 0)
            {
                return 1 / MyPow(x, -n);
            }

            if (x == 0)
            {
                return 0;
            }

            if (x < 0)
            {
                return MyPow(-x, n) * (n % 2 == 0 ? 1 : -1);
            }

            if (n == 1)
            {
                return x;
            }

            if (n > 512)
            {
                var a = n / 2;

                var b = MyPow(x, a);

                var c = b * b;

                if (n % 2 == 1)
                {
                    c *= x;
                }

                return c;
            }
            else
            {
                var pow = 1.0;

                for (int i = 0; i < n; i++)
                {
                    pow *= x;
                }
                
                return pow;
            }            
        }
    }
}
