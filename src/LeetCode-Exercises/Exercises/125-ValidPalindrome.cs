using LeetCode.Attributes;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ValidPalindrome
    {
        public static void Run()
        {
            var ex = new ValidPalindrome();

            do
            {
                Console.WriteLine("Enter str");
                var s = Console.ReadLine();

                if (String.IsNullOrEmpty(s))
                {
                    break;
                }

                var palin = ex.IsPalindrome(s);

                Console.WriteLine("Is Palindrome: {0}", palin);
                Console.WriteLine();

            } while (true);
        }

        public bool IsPalindrome(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return true;
            }

            var left = -1;
            var right = s.Length;

            while (left < right)
            {
                left = NextLeft(s, left);
                right = NextRight(s, right);

                if (left >= right)
                {
                    break;
                }

                var a = s[left] >= 'a' ? s[left] - 32 : s[left];
                var b = s[right] >= 'a' ? s[right] - 32 : s[right];

                if (a != b)
                {
                    return false;
                }
            }

            return true;
        }

        private int NextLeft(string s, int left)
        {
            left++;

            for (; left < s.Length; left++)
            {
                var c = s[left];

                if (char.IsLower(c) || char.IsUpper(c) || char.IsDigit(c))
                {
                    break;
                }
            }

            return left;
        }

        private int NextRight(string s, int right)
        {
            right--;

            for (; right >= 0; right--)
            {
                var c = s[right];

                if (char.IsLower(c) || char.IsUpper(c) || char.IsDigit(c))
                {
                    break;
                }
            }

            return right;
        }
    }
}
