using LeetCode.Attributes;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ValidParentheses
    {
        public static void Run()
        {
            var exercise = new ValidParentheses();

            var inputs = new[] { "()", "()[]{}", "", "(]", "([)]", "{[]}" };

            foreach (var input in inputs)
            {
                var solution = exercise.IsValid(input);

                Console.WriteLine("{0}: {1}", String.Join(", ", input), solution);
            }
        }

        private IDictionary<char, char> open = new Dictionary<char, char>
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

        public bool IsValid(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
                return true;

            if (s.Length % 2 == 1)
                return false;

            var stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (open.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    if (open[stack.Pop()] != c)
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
