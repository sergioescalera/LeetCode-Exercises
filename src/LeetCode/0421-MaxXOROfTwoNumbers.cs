using LeetCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class MaxXOROfTwoNumbers
    {
        public int FindMaximumXOR(int[] nums)
        {
            if (nums == null)
            {
                return int.MinValue;
            }

            if (nums.Length <= 1)
            {
                return 0;
            }

            var maxNum = nums.Max();
            var maxNumBin = ToBinary(maxNum);

            var trie = new Trie<char>();
            var numbers = new List<char[]>(nums.Length);
            var max = int.MinValue;
            var index = 0;

            foreach (var num in nums)
            {
                if (num < 0)
                {
                    throw new InvalidOperationException(
                        $"Negative numbers are not supported nums[{index}]={num}.");
                }

                var bin = ToBinary(num)
                    .PadLeft(maxNumBin.Length, '0')
                    .ToArray();

                trie.Add(bin);

                numbers.Add(bin);

                index++;
            }

            foreach (var binary in numbers)
            {
                var numMax = GetMax(trie.Nodes, binary);

                if (numMax > max)
                {
                    max = numMax;
                }
            }

            return max;
        }

        private string ToBinary(int num)
        {
            return Convert.ToString(num, 2);
        }

        private int GetMax(
            SortedDictionary<char, TrieNode<char>> nodes,
            char[] num, 
            int index = 0)
        {
            if (index >= num.Length)
            {
                return 0;
            }

            var bit = num[index];

            var notBit = bit == '0' ? '1' : '0';

            if (nodes.ContainsKey(notBit))
            {
                var bitValue = Convert.ToInt32(Math.Pow(2, num.Length - index - 1));

                return bitValue + GetMax(nodes[notBit].Children, num, index + 1);
            }

            return GetMax(nodes[bit].Children, num, index + 1);
        }

        public int FindMaximumXOR_N2(int[] nums)
        {

            if (nums == null)
            {
                return int.MinValue;
            }

            if (nums.Length <= 1)
            {
                return 0;
            }

            var max = int.MinValue;

            for (int i = 0; i < nums.Length - 1; i++)
            {

                for (int j = i + 1; j < nums.Length; j++)
                {

                    var xor = nums[i] ^ nums[j];

                    if (xor > max)
                    {
                        max = xor;
                    }
                }
            }

            return max;
        }
    }
}
