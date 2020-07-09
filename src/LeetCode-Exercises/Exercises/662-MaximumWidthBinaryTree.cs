using LeetCode.Attributes;
using LeetCode.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class MaximumWidthBinaryTree
    {
        public static void Run()
        {
            var tree = new TreeNode(
                1,
                new TreeNode(
                    3,
                    new TreeNode(
                        5,
                        new TreeNode(4)),
                    new TreeNode(6)),
                new TreeNode(
                    2,
                    null,
                    new TreeNode(
                        9,
                        null,
                        new TreeNode(11))));

            var exercise = new MaximumWidthBinaryTree();

            var width = exercise.WidthOfBinaryTree(tree);

            Debugger.Break();
        }

        public int WidthOfBinaryTree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var positions = new List<Position>();

            AddPositions(root, positions);

            var byLevel = positions
                .GroupBy(o => o.level)
                .ToArray();

            var maxWidth = 1;

            foreach (var level in byLevel)
            {
                if (level.Count() == 1)
                {
                    continue;
                }

                var max = level.Max(o => o.index);

                var min = level.Min(o => o.index);

                var width = max - min + 1;

                if (width > maxWidth)
                {
                    maxWidth = width;
                }
            }

            return maxWidth;
        }

        private void AddPositions(
            TreeNode node, 
            List<Position> positions,
            int level = 1,
            int index = 0)
        {
            if (node == null)
            {
                return;
            }

            positions.Add(new Position
            {
                level = level,
                index = index,
                value = node.val
            });

            AddPositions(
                node.left,
                positions, 
                level + 1, 
                index * 2);

            AddPositions(
                node.right, 
                positions, 
                level + 1,
                index * 2 + 1);
        }

        [DebuggerDisplay("level: {level}, index: {index}, val: {value}")]
        class Position
        {
            public int level;

            public int index;

            public int value;
        }
    }
}
