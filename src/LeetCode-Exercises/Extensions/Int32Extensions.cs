using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LeetCode.Extensions
{
    public static class Int32Extensions
    {
        public static Boolean GetBit(this Int32 n, Int32 i)
        {
            return ((1 << i) & n) != 0;
        }

        public static Int32 SetBit(this Int32 n, Int32 i)
        {
            return n | (1 << i);
        }

        public static Int32 ClearBit(this Int32 n, Int32 i)
        {
            return n & ~(1 << i);
        }

        public static Int32 ClearBitsLeft(this Int32 n, Int32 i)
        {
            return n & ((1 << i) - 1);
        }

        public static Int32 ClearBitsRight(this Int32 n, Int32 i)
        {
            return n & (-1 << (i + 1));
        }

        public static String ToBinary(this UInt32 n)
        {
            var a = new List<char>(32);

            var c = n;

            do
            {
                if (c % 2 == 0)
                {
                    a.Add('0');
                }
                else
                {
                    a.Add('1');
                }

                c = c / 2;

            } while (c > 0);

            a.Reverse();

            return new string(a.ToArray());
        }
    }
}
