using LeetCode.Data;
using System;

namespace LeetCode
{
    public class DeleteNodeInBST
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
            {
                return null;
            }

            return FindAndDeleteNode(root, key);
        }

        private TreeNode FindAndDeleteNode(TreeNode node, int key)
        {
            if (node == null)
            {
                return null;
            }

            if (node.val == key)
            {
                if (node.left == null)
                {
                    return node.right;
                }

                if (node.right == null)
                {
                    return node.left;
                }

                var max = FindMax(node.left);

                max.right = node.right;

                return node.left;
            }

            if (key > node.val)
            {
                node.right = FindAndDeleteNode(node.right, key);
            }
            else
            {
                node.left = FindAndDeleteNode(node.left, key);
            }

            return node;
        }

        private TreeNode FindMax(TreeNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.right == null)
            {
                return node;
            }

            return FindMax(node.right);
        }
    }
}
