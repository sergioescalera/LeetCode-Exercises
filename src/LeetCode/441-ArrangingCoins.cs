using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class ArrangingCoins
    {
        public int ArrangeCoins(int n)
        {
            if (n < 0)
                return -1;

            if (n == 0 || n == 1)
                return n;

            return ArrangeCoins(n, 1, n / 2 + 1);
        }

        private int ArrangeCoins(int n, int start, int end)
        {
            var val1 = start * (start + 1) / 2;
            var val2 = end * (end + 1) / 2;

            if (val1 == n)
            {
                return start;
            }

            if (val2 == n)
            {
                return end;
            }

            if (start + 1 >= end)
            {
                return val2 < n ? end : start;
            }

            if (val2 < n)
            {
                return end;
            }

            var middle = start + (end - start) / 2;

            if (middle * (middle + 1) / 2 <= n)
            {
                return ArrangeCoins(n, middle, end);
            }

            return ArrangeCoins(n, start, middle);
        }
    }
}
