using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class NumbersWithSameConsecutiveDifferences
    {
        public static void Run()
        {
            var ex = new NumbersWithSameConsecutiveDifferences();

            do
            {
                var n = ex.ReadNum("Enter n");

                if (n == null)
                    break;

                var k = ex.ReadNum("Enter k");

                if (k == null)
                    break;

                var nums = ex.NumsSameConsecDiff(n.Value, k.Value);

                Console.WriteLine(String.Join(", ", nums));

            } while (true);
        }

        /*
         * 
         Input: N = 3, K = 7
         Output: [181,292,707,818,929]
         *
         */
        /// <summary>
        /// Returns all non-negative integers of length N such that the absolute difference
        /// between every two consecutive digits is K.
        /// </summary>
        /// <param name="N"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int[] NumsSameConsecDiff(int n, int k)
        {
            if (n < 1 || n > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            if (k < 0 || k > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            if (n == 1)
            {
                return Enumerable.Range(0, 10).ToArray();
            }

            var list = new List<int>();

            for (byte i = 1; i < 10; i++)
            {
                var digits = new byte[n];

                digits[0] = i;

                NumsSameConsecDiff(1, (byte)k, digits, list);
            }

            return list.ToArray();
        }

        private void NumsSameConsecDiff(byte index, byte k, byte[] digits, List<int> list)
        {
            if (index >= digits.Length)
            {
                list.Add(ToNumber(digits));
            }
            else
            {
                byte prev = digits[index - 1];
                
                if (prev + k < 10)
                {
                    digits[index] = (byte)(prev + k);

                    NumsSameConsecDiff((byte)(index + 1), k, digits, list);
                }

                if (prev - k >= 0 && k != 0)
                {
                    digits[index] = (byte)(prev - k);

                    NumsSameConsecDiff((byte)(index + 1), k, digits, list);
                }
            }
        }

        private int ToNumber(byte[] digits)
        {
            var n = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                n += (int)Math.Pow(10, digits.Length - 1 - i) * digits[i];
            }

            return n;
        }
    }
}
