using LeetCode.Attributes;
using LeetCode.Input;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SubtreeAnotherTree
    {
        public static void Run()
        {
        }

        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (t == null)
                return s == null;

            if (s == null)
                return false;

            if (s.val == t.val &&
                IsSame(s.left, t.left) &&
                IsSame(s.right, t.right))
            {
                return true;
            }

            return IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }

        private bool IsSame(TreeNode a, TreeNode b)
        {
            if (a == null)
                return b == null;

            if (b == null)
                return false;

            if (a.val != b.val)
                return false;

            return IsSame(a.left, b.left)
                && IsSame(a.right, b.right);
        }
    }
}
