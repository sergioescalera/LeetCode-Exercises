using LeetCode.Attributes;
using LeetCode.Extensions;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class PowerOfTwo
    {
        public static void Run()
        {
            var ex = new PowerOfTwo();

            do
            {
                var n = ex.ReadNum();

                if (n == null)
                    break;

                var isPower = ex.IsPowerOfTwo(n.Value);

                Console.WriteLine(isPower);

            } while (true);
        }

        public bool IsPowerOfTwo(int n)
        {
            if (n < 1)
            {
                return false;
            }

            return (n & (n - 1)) == 0;
        }
    }
}
