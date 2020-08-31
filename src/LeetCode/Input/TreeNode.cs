using System;
using System.Diagnostics;

namespace LeetCode.Input
{
    [DebuggerDisplay("{val}: [{left}], [{right}]")]
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

        public override Boolean Equals(object obj)
        {
            return obj is TreeNode tree
                && AreEquals(this, tree);
        }

        public static Boolean AreEquals(TreeNode node, TreeNode other)
        {
            if (node == null)
            {
                return other == null;
            }

            if (other == null)
            {
                return node == null;
            }

            return node.val == other.val
                && AreEquals(node.left, other.left)
                && AreEquals(node.right, other.right);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual object Clone()
        {
            return new TreeNode
            {
                val = val,
                left = left?.Clone() as TreeNode,
                right = right?.Clone() as TreeNode
            };
        }
    }
}