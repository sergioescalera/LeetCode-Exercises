using LeetCode.Attributes;
using LeetCode.Input;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SumLeftLeaves
    {
        public static void Run()
        {
            var ex = new SumLeftLeaves();

            do
            {
                

            } while (true);
        }

        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.left == null && root.right == null)
            {
                return 0;
            }

            return SumOfLeftLeaves(root.left, true) + SumOfLeftLeaves(root.right, false);
        }

        private int SumOfLeftLeaves(TreeNode node, bool isLeftNode)
        {
            if (node == null)
            {
                return 0;
            }

            if (node.left == null && node.right == null)
            {
                return isLeftNode ? node.val : 0;
            }

            return SumOfLeftLeaves(node.left, true) + SumOfLeftLeaves(node.right, false);
        }
    }
}
