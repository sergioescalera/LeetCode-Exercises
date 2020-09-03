using System;

namespace LeetCode
{
    public class RepeatedSubstringPatternSolution
    {
        public bool RepeatedSubstringPattern(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }

            if (s.Length == 1)
            {
                return false;
            }

            var half = s.Length / 2;

            for (int len = 1; len <= half; len++)
            {
                if (s.Length % len != 0)
                {
                    continue;
                }

                var pattern = s.Substring(0, len);

                if (CheckPattern(s, pattern))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckPattern(string s, string pattern)
        {
            var count = s.Length / pattern.Length;

            for (int skip = 1; skip < count; skip++)
            {
                if (pattern != s.Substring(skip * pattern.Length, pattern.Length))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
