using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Exercises
{
    [Exercise]
    public class MultiplyStrings
    {
        public static void Run()
        {
            var exercise = new MultiplyStrings();

            do
            {
                Console.WriteLine("Enter a, b:");

                var a = Console.ReadLine();
                var b = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(a) || String.IsNullOrWhiteSpace(b))
                {
                    break;
                }

                var c = exercise.Multiply(a, b);

                Console.WriteLine("{0}x{1}={2}", a, b, c);
                Console.WriteLine();

            } while (true);
        }

        static readonly Dictionary<char, Int32> digits = new Dictionary<char, Int32>
        {
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 }
        };

        public string Multiply(string num1, string num2)
        {
            if (num1 == null || num2 == null)
            {
                return null;
            }

            if (num1 == "0" || num2 == "0")
            {
                return "0";
            }

            var numbers = Enumerable.Repeat(0, num1.Length + num2.Length).ToArray();

            for (int i = 0; i < num2.Length; i++)
            {
                for (int j = num1.Length - 1; j >= 0; j--)
                {
                    var current = i + j + 1;
                    
                    var c1 = num1[j];
                    var c2 = num2[i];

                    if (!digits.ContainsKey(c1))
                    {
                        throw new ArgumentException("Invalid digit found" + c1);
                    }

                    if (!digits.ContainsKey(c2))
                    {
                        throw new ArgumentException("Invalid digit found" + c2);
                    }

                    var d1 = digits[c1];
                    var d2 = digits[c2];

                    numbers[current] = numbers[current] + d1 * d2;
                }
            }

            var sb = new char[numbers.Length];

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                var r = numbers[i] % 10;
                var d = numbers[i] / 10;

                sb[i] = r.ToString().Single();

                if (d >= 1)
                {
                    numbers[i - 1] = numbers[i - 1] + d;
                }
            }


            return new string(sb).TrimStart('0');
        }
    }
}
