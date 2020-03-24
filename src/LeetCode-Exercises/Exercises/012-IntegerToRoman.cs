using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class IntegerToRoman
    {
        public static void Run()
        {
            var exercise = new IntegerToRoman();

            do
            {
                var n = exercise.ReadNum();

                if (n == null)
                    break;

                Console.WriteLine("{0}={1}", n, exercise.IntToRoman(n.Value));

            } while (true);
        }

        public string IntToRoman(int num)
        {
            if (num <= 0 || num > 3999)
                return "";

            if (num <= 3)
                return new string(new char[num].Select(x => 'I').ToArray());

            if (num == 4)
            {
                return "IV";
            }

            if (num == 5)
            {
                return "V";
            }

            if (num < 9)
            {
                return "V" + IntToRoman(num - 5);
            }

            if (num == 9)
            {
                return "IX";
            }

            var log10 = Math.Log10(num);

            if (log10 < 2)
            {
                var s = num / 10;

                if (s <= 3)
                {
                    return new string(new char[s].Select(x => 'X').ToArray()) + IntToRoman(num - s * 10);
                }

                if (s == 4)
                {
                    return "XL" + IntToRoman(num - 40);
                }

                if (s == 5)
                {
                    return "L" + IntToRoman(num - 50);
                }

                if (s < 9)
                {
                    return "L" + new string(new char[s - 5].Select(x => 'X').ToArray()) + IntToRoman(num - s * 10);
                }

                if (s == 9)
                {
                    return "XC" + IntToRoman(num - 90);
                }

                throw new InvalidOperationException();
            }

            if (log10 < 3)
            {
                var c = num / 100;

                if (c <= 3)
                {
                    return new string(new char[c].Select(x => 'C').ToArray()) + IntToRoman(num - c * 100);
                }
                
                if (c == 4)
                {
                    return "CD" + IntToRoman(num - 400);
                }
                
                if (c == 5)
                {
                    return "D" + IntToRoman(num - 500);
                }

                if (c < 9)
                {
                    return "D" + new string(new char[c - 5].Select(x => 'C').ToArray()) + IntToRoman(num - c * 100);
                }

                if (c == 9)
                {
                    return "CM" + IntToRoman(num - 900);
                }

                throw new InvalidOperationException();
            }

            var m = num / 1000;

            if (m >= 4)
                throw new NotSupportedException();

            return new string(new char[m].Select(x => 'M').ToArray()) + IntToRoman(num - m * 1000);
        }
    }
}
