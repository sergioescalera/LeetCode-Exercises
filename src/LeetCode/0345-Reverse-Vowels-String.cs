using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class ReverseString
    {
        private readonly Func<char, bool> _shouldReverseChar;

        public ReverseString(Func<char, bool> shouldReverseChar = null)
        {
            var vowels = new HashSet<char>(new[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' });

            _shouldReverseChar = shouldReverseChar ?? ((c) => vowels.Contains(c));
        }

        public string Reverse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            var chars = s.ToCharArray();

            var start = 0;
            var end = chars.Length - 1;

            while (start < end)
            {
                while (start <= end && !_shouldReverseChar(s[start]))
                {
                    start++;
                }

                while (start <= end && !_shouldReverseChar(s[end]))
                {
                    end--;
                }

                if (start < end)
                {
                    Swap(chars, start, end);
                    start++;
                    end--;
                }
            }

            return new string(chars);
        }

        void Swap(char[] chars, int start, int end)
        {
            var temp = chars[start];

            chars[start] = chars[end];
            chars[end] = temp;
        }
    }
}
