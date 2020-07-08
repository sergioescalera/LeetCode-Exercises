using LeetCode.Attributes;
using LeetCode.Input;
using System;

namespace LeetCode.Exercises
{
    /// <summary>
    /// A height-balanced binary tree is defined as:
    /// A binary tree in which the left and right subtrees of every node differ in height by no more than 1.
    /// </summary>
    [Exercise]
    public class BalancedBinaryTree
    {
        public static void Run()
        {

        }

        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return GetBalanced(root) >= 0;
        }

        int GetBalanced(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            var left = GetBalanced(node.left);

            if (left < 0)
            {
                return -1;
            }

            var right = GetBalanced(node.right);

            if (right < 0)
            {
                return -1;
            }

            var diff = Math.Abs(right - left);

            if (diff > 1)
            {
                return -1;
            }

            return Math.Max(left, right) + 1;
        }
    }
}
