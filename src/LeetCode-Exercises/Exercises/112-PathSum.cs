using LeetCode.Attributes;
using LeetCode.Input;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class PathSum
    {
        public static void Run()
        {
        }

        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            var left = GetSums(root.left);

            if (left != null &&
                left.Any(o => o + root.val == sum))
                return true;

            var right = GetSums(root.right);

            if (right != null &&
                right.Any(o => o + root.val == sum))
                return true;

            return left == null && right == null && root.val == sum;
        }

        private IEnumerable<int> GetSums(TreeNode node)
        {
            if (node == null)
                return null;

            var left = GetSums(node.left);

            var right = GetSums(node.right);

            if (left == null && right == null)
                return new[] { node.val };

            if (left == null)
                return right.Select(o => o + node.val);

            if (right == null)
                return left.Select(o => o + node.val);

            var sums = left
                .Union(right)
                .Select(o => o + node.val);

            return sums;
        }
    }
}
