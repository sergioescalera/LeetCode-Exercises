using LeetCode.Attributes;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ExcelSheetColumnNumber
    {
        public static void Run()
        {
            var ex = new ExcelSheetColumnNumber();

            do
            {
                Console.WriteLine("Enter column");

                var line = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                var n = ex.TitleToNumber(line);

                Console.WriteLine(n);
                Console.WriteLine();

            } while (true);
        }

        public int TitleToNumber(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                throw new ArgumentException();
            }

            var zero = 64;
            var value = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                var v = (int)c - zero;

                value += v * (int)Math.Pow(26, s.Length - i - 1);
            }

            return value;
        }
    }
}
