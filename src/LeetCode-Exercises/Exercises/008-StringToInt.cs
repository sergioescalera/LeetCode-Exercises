using LeetCode.Attributes;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class StringToInt
    {
        public static void Run()
        {
            var exercice = new StringToInt();

            do
            {
                var l = Console.ReadLine();

                if (String.IsNullOrEmpty(l))
                    break;

                Console.WriteLine("{0}={1}", l, exercice.MyAtoi(l));

            } while (true);
        }

        static readonly string max = int.MaxValue.ToString();

        public int MyAtoi(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                return 0;

            if (!FindFirst(str, out var start, out var negative))
            {
                return 0;
            }

            if (!FindLast(str, start, out var end))
            {
                return 0;
            }

            var chunk = str
                .Substring(start, end - start + 1)
                .PadLeft(max.Length, '0');

            if (chunk.CompareTo(max.PadLeft(chunk.Length, '0')) > 0)
            {
                return negative ? int.MinValue : int.MaxValue;
            }

            var n = int.Parse(chunk);

            return negative ? -n : n;
        }

        private bool FindFirst(string str, out int start, out bool negative)
        {
            start = -1;
            negative = false;

            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];

                if (c >= '0' && c <= '9')
                {
                    start = i;

                    return true;
                }

                var j = i + 1;

                if (c == '+')
                {
                    if (j < str.Length)
                    {
                        var n = str[j];

                        if (n >= '0' && n <= '9')
                        {
                            start = j;

                            return true;
                        }
                    }

                    return false;
                }

                if (c == '-')
                {
                    if (j < str.Length)
                    {
                        var n = str[j];

                        if (n >= '0' && n <= '9')
                        {
                            start = j;
                            negative = true;

                            return true;
                        }
                    }

                    return false;
                }

                if (c != ' ')
                {
                    return false;
                }
            }

            return false;
        }

        private bool FindLast(string str, int start, out int end)
        {
            end = -1;

            for (int i = start + 1; i < str.Length; i++)
            {
                var c = str[i];

                if (c < '0' || c > '9')
                {
                    end = i - 1;

                    return true;
                }
            }

            end = str.Length - 1;

            return true;
        }
    }
}
