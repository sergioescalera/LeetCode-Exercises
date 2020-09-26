using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class LargestNumberSolution
    {
        public string LargestNumber(int[] nums)
        {

            if (nums == null || nums.Length == 0)
            {
                return "";
            }

            var sorted = nums
                .Select(n => new Digits(n))
                .OrderByDescending(d => d, new Comparer())
                .Select(d => d.n);

            var str = string.Join("", sorted).TrimStart('0');

            if (string.IsNullOrEmpty(str))
            {
                return "0";
            }

            return str;
        }

        class Digits
        {

            public readonly byte[] digits;

            public readonly int n;

            public Digits(int n)
            {
                this.n = n;
                this.digits = GetDigits(n).ToArray();
            }

            public Digits(byte[] digits)
            {
                this.digits = digits;
            }

            private IEnumerable<byte> GetDigits(int n)
            {

                do
                {
                    yield return (byte)(n % 10);

                    n /= 10;

                } while (n > 0);

                yield break;
            }

            public override string ToString()
            {
                return string.Join("", digits);
            }
        }

        class Comparer : IComparer<Digits>
        {

            public int Compare(Digits x, Digits y)
            {
                int len = Math.Min(x.digits.Length, y.digits.Length);

                for (int i = 1; i <= len; i++)
                {

                    if (x.digits[x.digits.Length - i] ==
                        y.digits[y.digits.Length - i])
                    {
                        continue;
                    }

                    return x.digits[x.digits.Length - i] - y.digits[y.digits.Length - i];
                }

                if (x.digits.Length == y.digits.Length)
                {
                    return 0;
                }

                if (x.digits.Length > y.digits.Length)
                {
                    return Compare(new Digits(x.digits.Take(x.digits.Length - len).ToArray()), y);
                }

                return Compare(x, new Digits(y.digits.Take(y.digits.Length - len).ToArray()));
            }
        }
    }
}
