using LeetCode.Attributes;
using LeetCode.Input;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class PathSumIIIExercise
    {
        public static void Run()
        {
            var ex = new PathSumIIIExercise();

            var tree = new TreeNode(
                10,
                new TreeNode(
                    5,
                    new TreeNode(
                        3,
                        new TreeNode(3),
                        new TreeNode(-2)),
                    new TreeNode(
                        2,
                        null,
                        new TreeNode(1))),
                new TreeNode(
                    -3,
                    null,
                    new TreeNode(11)));

            var count = ex.PathSum(tree, 8);
        }

        public int PathSum(TreeNode root, int sum)
        {
            if (root == null)
                return 0;

            var count = 0;

            if (root.val == sum)
            {
                count++;
            }

            count += PathSum(root.left, sum);
            count += PathSumNode(root.left, sum - root.val);
            count += PathSum(root.right, sum);
            count += PathSumNode(root.right, sum - root.val);

            return count;
        }

        private int PathSumNode(TreeNode node, int sum)
        {
            if (node == null)
                return 0;

            var count = 0;

            if (node.val == sum)
                count++;

            count += PathSumNode(node.left, sum - node.val);
            count += PathSumNode(node.right, sum - node.val);

            return count;
        }
    }
}
