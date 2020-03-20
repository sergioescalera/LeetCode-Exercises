using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class LongestPalindromicSubstring
    {
        public static void Run()
        {
            var exercise = new LongestPalindromicSubstring();

            do
            {
                Console.WriteLine("Enter string");

                var line = Console.ReadLine();

                if (String.IsNullOrEmpty(line))
                {
                    return;
                }

                var solution = exercise.LongestPalindrome(line);

                Console.WriteLine("Longest palindrome: {0}", solution);

            } while (true);
        }

        public string LongestPalindrome(string s)
        {
            if (s == null || s == "")
                return s;

            var t = LongestPalindrome(s, 0);

            if (t.Item1.Length >= t.Item2.Length)
            {
                return t.Item1;
            }

            return t.Item2;
        }

        public Tuple<string, string> LongestPalindrome(string s, int index)
        {
            if (index >= s.Length)
            {
                return Tuple.Create("", "");
            }

            var c = s[index];

            if (index == s.Length - 1)
            {
                return Tuple.Create("" + c, "");
            }

            var t = LongestPalindrome(s, index + 1);
            var j = index + t.Item1.Length + 1;
            var k = index + t.Item1.Length;

            var a = j < s.Length && c == s[j] ? 
                c + t.Item1 + c :
                c == s[k] && IsPalindrome(c + t.Item1) ?
                c + t.Item1 :
                c + "";

            var b = t.Item1.Length >= t.Item2.Length ? t.Item1 : t.Item2;

            return Tuple.Create(a, b);
        }

        private string LongestPalindromeBruteForce(string s)
        {
            for (int l = s.Length; l > 0; l--)
            {
                for (int i = 0; i <= s.Length - l; i++)
                {
                    var str = s.Substring(i, l);

                    if (IsPalindrome(str))
                        return str;
                }
            }

            throw new ArgumentException();
        }

        private static bool IsPalindrome(string str)
        {
            var h = str.Length / 2;
            for (int i = 0; i < h; i++)
            {
                if (str[i] != str[str.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }
}
