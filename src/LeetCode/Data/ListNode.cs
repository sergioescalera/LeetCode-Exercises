using System;
using System.Diagnostics;
using System.Linq;

namespace LeetCode.Data
{
    [DebuggerDisplay("{val} -> {next}")]
    public class ListNode
    {
        public Int32 val;
        public ListNode next;

        public ListNode(Int32 val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public ListNode(String str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return;
            }

            var numbers = str
                .Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s))
                .ToArray();

            val = numbers.FirstOrDefault();

            if (numbers.Skip(1).Any())
            {
                next = new ListNode(string.Join(", ", numbers.Skip(1)));
            }
        }

        public void PrintPretty()
        {
            PrintPretty(first: true);
        }

        private void PrintPretty(Boolean first)
        {
            if (first)
            {
                Console.Write("(");
            }

            Console.Write(val);

            var last = next == null;

            if (last)
            {
                Console.Write(")");
                Console.WriteLine();
            }
            else
            {
                Console.Write("->");
                next.PrintPretty(first: false);
            }
        }

        public override string ToString()
        {
            if (next == null)
            {
                return val.ToString();
            }

            return $"{val}, {next.ToString(1)}";
        }

        private String ToString(int depth, int maxDepth = 10)
        {
            if (depth > maxDepth && next != null)
            {
                return $"{val}...";
            }

            if (next == null)
            {
                return val.ToString();
            }

            return $"{val}, {next.ToString(depth + 1, maxDepth)}";
        }
    }
}
