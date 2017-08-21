using LeetCode.Attributes;
using LeetCode.Input;

namespace LeetCode.Exercises
{
    [Exercise]
    public static class MergeTwoBinaryTrees
    {
        public static void Run()
        {
            var t1 = new TreeNode(1)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(5)
                },
                right = new TreeNode(2)
            };

            var t2 = new TreeNode(2)
            {
                left = new TreeNode(1)
                {
                    right = new TreeNode(4)
                },
                right = new TreeNode(3)
                {
                    right = new TreeNode(7)
                }
            };

            t1.PrintPretty();
            t2.PrintPretty();

            var merged = MergeTrees(t1, t2);

            merged.PrintPretty();
        }

        public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return null;

            if (t2 == null)
                return t1;

            if (t1 == null)
                return t2;

            return new TreeNode(t1.val + t2.val)
            {
                left = MergeTrees(t1.left, t2.left),
                right = MergeTrees(t1.right, t2.right)
            };
        }
    }
}
