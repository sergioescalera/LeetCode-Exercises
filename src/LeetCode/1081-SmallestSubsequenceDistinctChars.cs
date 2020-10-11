using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class SmallestSubsequenceDistinctChars
    {
        public String SmallestSubsequence(String s)
        {
            var stack = new Stack<char>();

            int[] last = new int[26];
            int[] visited = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                last[s[i] - 'a'] = i;
            }

            for (int i = 0; i < s.Length; i++)
            {
                int c = s[i] - 'a';

                if (visited[c] > 0)
                {
                    continue;
                }

                visited[c]++;

                while (stack.Any() && stack.Peek() > s[i] && i < last[stack.Peek() - 'a'])
                {
                    visited[stack.Pop() - 'a'] = 0;
                }

                stack.Push(s[i]);
            }

            var sb = new StringBuilder();

            foreach (var c in stack)
            {
                sb.Insert(0, c);
            } 
                
            return sb.ToString();
        }
    }
}
