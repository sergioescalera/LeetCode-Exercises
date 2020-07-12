using LeetCode.Attributes;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ReverseBits
    {
        public static void Run()
        {

        }

        public uint reverseBits(uint n)
        {
            if (n == 0)
            {
                return 0;
            }
            
            string binaryArray = Convert.ToString(n, 2);
            int l = 32 - binaryArray.Length;
            uint r = 0;

            for (int i = binaryArray.Length - 1; i >= 0; i--)
            {
                if (binaryArray[i] == '1')
                {
                    r += (uint)Math.Pow(2, i + l);
                }
            }

            return r;
        }
    }
}
