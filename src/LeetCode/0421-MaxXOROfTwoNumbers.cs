using LeetCode.Data;
using System;
using System.Collections;
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

            var n = nums.Max();
            var k = n >= Math.Pow(2, 16) ? 32 : n >= Math.Pow(2, 8) ? 16 : 8;
            var trie = new Trie<bool>();
            var max = int.MinValue;
            
            foreach (var num in nums)
            {
                var bin = new IntBinary(num, k);

                var numMax = GetMax(trie.Nodes, bin, 0);

                if (numMax > max)
                {
                    max = numMax;
                }

                trie.Add(bin);
            }

            return max;
        }
        
        private int GetMax(
            SortedDictionary<bool, TrieNode<bool>> nodes,
            IntBinary num, 
            int index)
        {
            if (index >= num.Count)
            {
                return 0;
            }

            var bit = num[index];

            var notBit = !bit;

            if (nodes.ContainsKey(notBit))
            {
                var bitValue = Convert.ToInt32(Math.Pow(2, num.Count - index - 1));

                return bitValue 
                    + GetMax(nodes[notBit].Children, num, index + 1);
            }

            if (nodes.ContainsKey(bit))
            {
                return GetMax(nodes[bit].Children, num, index + 1);
            }

            return 0;
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
