using LeetCode.Attributes;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ImplementStrStr
    {
        public static void Run()
        {
            var exercise = new ImplementStrStr();

            var solution = exercise.StrStr("hello", "ll");
        }

        public int StrStr(string haystack, string needle)
        {
            if (String.IsNullOrEmpty(needle))
            {
                return 0;
            }

            if (String.IsNullOrEmpty(haystack))
            {
                return -1;
            }

            if (needle.Length > haystack.Length)
            {
                return -1;
            }

            for (int i = 0; i < haystack.Length; i++)
            {
                for (int j = 0; j < needle.Length && j + i < haystack.Length; j++)
                {
                    var a = haystack[i + j];
                    var b = needle[j];

                    if (a  != b)
                    {
                        break;
                    }

                    if (a == b && j == needle.Length - 1)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
