using LeetCode.Attributes;
using LeetCode.Input;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class PathSumII
    {
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {

            if (root == null)
            {
                return new List<IList<int>> { };
            }

            if (root.val == sum && root.left == null && root.right == null)
            {
                return new List<IList<int>> { new List<int>() { root.val } };
            }

            var val = sum - root.val;

            var paths = new List<IList<int>>();

            AddPaths(paths, PathSum(root.left, val), root.val);

            AddPaths(paths, PathSum(root.right, val), root.val);

            return paths;
        }

        private void AddPaths(List<IList<int>> list, IList<IList<int>> paths, int val)
        {
            if (paths == null)
            {
                return;
            }

            foreach (var path in paths)
            {
                path.Insert(0, val);

                list.Add(path);
            }
        }
    }
}
