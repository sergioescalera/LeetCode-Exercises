using System;

namespace LeetCode.Data
{
    public class TreeNode : ICloneable
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public virtual object Clone()
        {
            return new TreeNode(
                val,
                left?.Clone() as TreeNode,
                right?.Clone() as TreeNode);
        }

        public override bool Equals(object obj)
        {
            return obj is TreeNode t
                && t.val == val
                && ((right == null && t.right == null || right.Equals(t.right)))
                && ((left == null && t.left == null || left.Equals(t.left)));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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