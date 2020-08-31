using LeetCode.Input;
using System;

namespace LeetCode
{
    public class DeleteNodeInBST
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
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
    }
}
