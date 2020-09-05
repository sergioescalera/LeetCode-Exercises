using System;
using System.Diagnostics;

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

            return $"{val}, {next}";
        }
    }
}
