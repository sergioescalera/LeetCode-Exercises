using System.Collections.Generic;

namespace LeetCode
{
    public class BasicCalculatorII
    {
        public int Calculate(string s)
        {

            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var exp = s.Trim().Replace(" ", "");

            var n = exp.Length;
            var stack = new Stack<int>();

            var currentNumber = 0;

            var op = '+';

            for (var i = 0; i < n; i++)
            {

                var c = exp[i];

                if (char.IsDigit(c))
                {
                    currentNumber = currentNumber * 10 + (c - '0');
                }

                if (char.IsDigit(c) == false || i == n - 1)
                {
                    if (op == '-')
                    {
                        stack.Push(-currentNumber);
                    }

                    else if (op == '+')
                    {
                        stack.Push(currentNumber);
                    }

                    else if (op == '*')
                    {
                        stack.Push(stack.Pop() * currentNumber);
                    }

                    else if (op == '/')
                    {
                        stack.Push(stack.Pop() / currentNumber);
                    }

                    currentNumber = 0;
                    op = c;
                }
            }

            var result = 0;

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }
    }
}
