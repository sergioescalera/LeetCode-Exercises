using LeetCode.Attributes;
using LeetCode.Extensions;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class DivideTwoIntegers
    {
        public static void Run()
        {
            var div = new DivideTwoIntegers();

            do
            {
                var a = div.ReadNum();
                var b = div.ReadNum();

                if (a == null || b == null)
                    break;

                Console.WriteLine($"{a} / {b} = {div.Divide(a.Value, b.Value)}");

            } while (true);
        }

        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }

            if (dividend == 0)
            {
                return 0;
            }

            if (divisor == 1)
            {
                return dividend;
            }

            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            if (divisor == -1)
            {
                return 0 - dividend;
            }

            var s = (dividend < 0 && divisor < 0) || (dividend > 0 && divisor > 0);

            var a = dividend > 0 ? 0 - dividend : dividend;
            var b = divisor > 0 ? 0 - divisor : divisor;
            var c = 0;
            var i = 0;

            for (; c > a; i++)
            {
                c += b;
            }

            if (s)
            {
                return c < a ? i - 1 : i;
            }
            else
            {
                return 0 - (c < a ? i - 1 : i);
            }
        }
    }
}
