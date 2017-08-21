using System;

namespace LeetCode.Input
{
    public class TreeNode
    {
        public Int32 val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(Int32 val)
        {
            this.val = val;
        }

        public void PrintPretty(String indent = "", Boolean last = true)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.WriteLine(val);

            left?.PrintPretty(indent, last: right == null);
            right?.PrintPretty(indent, last: true);
        }
    }
}