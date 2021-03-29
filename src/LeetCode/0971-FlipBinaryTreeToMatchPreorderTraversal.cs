using LeetCode.Data;
using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class FlipBinaryTreeToMatchPreorderTraversal
    {
        public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
        {

            if (root == null)
            {
                return Array.Empty<int>();
            }

            var flip = FlipMatchVoyage(root, voyage, 0);

            if (flip.success)
            {
                return flip.list;
            }

            return new[] { -1 };
        }

        (IList<int> list, int count, bool success) FlipMatchVoyage(TreeNode node, int[] voyage, int index)
        {

            if (node == null)
            {
                return (Array.Empty<int>(), 0, true);
            }

            if (index >= voyage.Length || node.val != voyage[index])
            {
                return (Array.Empty<int>(), 0, false);
            }

            var list = new List<int>();

            if (node.left != null &&
                node.right != null &&
                index + 1 < voyage.Length &&
                node.right.val == voyage[index + 1])
            {
                var temp = node.right;

                node.right = node.left;
                node.left = temp;

                list.Add(node.val);
            }

            var left = FlipMatchVoyage(node.left, voyage, index + 1);

            if (!left.success)
            {
                return left;
            }

            var right = FlipMatchVoyage(node.right, voyage, index + 1 + left.count);

            if (!right.success)
            {
                return right;
            }

            list.AddRange(left.list);
            list.AddRange(right.list);

            return (list, left.count + right.count + 1, true);
        }
    }
}
