using LeetCode.Attributes;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class LongestPalindromeExercise
    {
        public int LongestPalindrome(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));

            var dict = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (dict.ContainsKey(c))
                {
                    dict[c] = dict[c] + 1;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            var even = 0;
            var odd = 0;

            foreach (var c in dict)
            {
                if (c.Value % 2 == 0)
                {
                    even += c.Value;
                }
                else
                {
                    odd += c.Value - 1;
                }
            }

            return even + odd + (odd > 0 ? 1 : 0);
        }
    }
}
