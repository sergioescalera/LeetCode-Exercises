using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class SequentialDigitsSolution
    {
        public IList<int> SequentialDigits(int low, int high)
        {
            int minDigits = (int)Math.Floor(Math.Log10(low)) + 1;
            int maxDigits = (int)Math.Floor(Math.Log10(high)) + 1;

            var list = new List<int>();
            
            for (int digitCount = minDigits; digitCount <= maxDigits; digitCount++)
            {
                int pow10 = (int)Math.Pow(10, digitCount - 1);

                int firstDigit = minDigits == digitCount ?
                    low / pow10 :
                    1;

                for (int digit = firstDigit; digit <= 9; digit++)
                {
                    if (digit * pow10 > high)
                    {
                        break;
                    }

                    foreach (var seq in SequentialDigits(maxDigits, digitCount - 1, digit))
                    {
                        var n = seq + digit * pow10;

                        if (low <= n && n <= high)
                        {
                            list.Add(n);
                        }
                        else if (n > high)
                        {
                            break;
                        }
                    }
                }
            }

            return list;
        }

        private IEnumerable<int> SequentialDigits(
            int digits,
            int index,
            int prev)
        {
            if (index == 1)
            {
                if (prev < 9)
                {
                    yield return prev + 1;
                }

            }
            else
            {
                if (prev < 9)
                {
                    var digit = prev + 1;

                    foreach (var seq in SequentialDigits(digits, index - 1, digit))
                    {
                        int pow10 = (int)Math.Pow(10, index - 1);

                        var n = seq + digit * pow10;

                        yield return n;
                    }
                }
            }

            yield break;
        }
    }
}
