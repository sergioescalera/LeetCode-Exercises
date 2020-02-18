using LeetCode.Attributes;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class PalindromeNumber
    {
        public static void Run()
        {
            var exercise = new PalindromeNumber();

            var s100 = exercise.IsPalindrome(100);
            var s123 = exercise.IsPalindrome(123);
            var s101 = exercise.IsPalindrome(101);
            var s1771 = exercise.IsPalindrome(1771);
            var s1000021 = exercise.IsPalindrome(1000021);
            var s1002001 = exercise.IsPalindrome(1002001);

            Console.WriteLine($"Is Palindrome of 100: {s100}");
            Console.WriteLine($"Is Palindrome of 123: {s123}");
            Console.WriteLine($"Is Palindrome of 101: {s101}");
            Console.WriteLine($"Is Palindrome of 1771: {s1771}");
            Console.WriteLine($"Is Palindrome of 1000021: {s1000021}");
            Console.WriteLine($"Is Palindrome of 1002001: {s1002001}");
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            if (x < 10)
            {
                return true;
            }

            var d = (Int32)Math.Floor(Math.Log10(x)) + 1;

            return IsPalindrome(x, d);
        }

        private bool IsPalindrome(int x, int d)
        {
            if (d <= 1)
                return true;

            var e = (Int32)Math.Pow(10, d - 1);
            var a = x / e;

            var b = x % 10;

            if (b != a)
            {
                return false;
            }

            var y = x - e * a;

            var z = (Int32)Math.Floor(y / 10.0);


            if (z == 0)
            {
                return true;
            }

            var dz = (Int32)Math.Ceiling(Math.Log10(z));

            return IsPalindrome(z, d - 2);
        }
    }
}
