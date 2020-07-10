using LeetCode.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    public class LowestCommonAncestorBinaryTree
    {
        public TreeNode LowestCommonAncestor(TreeNode node, TreeNode p, TreeNode q)
        {
            if (node == null)
            {
                return null;
            }

            if (p == null || q == null)
            {
                return null;
            }

            if (node == p && node == q)
            {
                return node;
            }

            var left = LowestCommonAncestor(node.left, p, q);

            if (left != null && left != p && left != q)
                return left;

            var right = LowestCommonAncestor(node.right, p, q);

            if (right != null && right != p && right != q)
                return right;

            if (left != null && right != null)
                return node;

            if (node == p || node == q)
                return node;

            return left ?? right;
        }
    }
}
