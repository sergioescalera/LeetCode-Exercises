using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Globalization;

namespace LeetCode.Exercises
{
    [Exercise]
    public class PowerOfFour
    {
        public static void Run()
        {
            var ex = new PowerOfFour();

            do
            {
                var n = ex.ReadNum();

                if (n == null)
                    break;

                var isPower = ex.IsPowerOfFour(n.Value);

                Console.WriteLine(isPower);

            } while (true);
        }

        public bool IsPowerOfFour(int num)
        {
            if (num < 1)
            {
                return false;
            }

            var log = Math.Log(num, 4);

            var ceil = Math.Ceiling(log);

            return ceil == num;
        }
    }
}
