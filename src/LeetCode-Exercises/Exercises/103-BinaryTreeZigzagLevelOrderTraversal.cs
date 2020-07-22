using LeetCode.Attributes;
using LeetCode.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class BinaryTreeZigzagLevelOrderTraversal
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }

            var list = new List<IList<int>>();

            var level = 0;

            var currentLevel = new List<int>();

            var queue = new Queue<TreeNodeLevel>();

            list.Add(currentLevel);

            queue.Enqueue(new TreeNodeLevel(root));

            while (queue.Any())
            {
                var item = queue.Dequeue();

                if (item.level > level)
                {
                    level++;

                    if (level % 2 == 0)
                    {
                        currentLevel.Reverse();
                    }

                    currentLevel = new List<int>();

                    list.Add(currentLevel);
                }

                currentLevel.Add(item.node.val);

                if (item.node.left != null)
                {
                    queue.Enqueue(new TreeNodeLevel(item.node.left, item.level + 1));
                }

                if (item.node.right != null)
                {
                    queue.Enqueue(new TreeNodeLevel(item.node.right, item.level + 1));
                }
            }

            if (level % 2 == 1)
            {
                currentLevel.Reverse();
            }

            return list;
        }

        class TreeNodeLevel
        {
            public TreeNode node;

            public int level;
            
            public TreeNodeLevel(TreeNode node, int level = 0)
            {
                this.node = node;
                this.level = level;
            }
        }
    }
}
