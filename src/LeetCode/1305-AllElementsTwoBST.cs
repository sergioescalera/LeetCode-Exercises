using LeetCode.Data;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class AllElementsTwoBST
    {
        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            var list1 = Enumarate(root1).ToArray();
            var list2 = Enumarate(root2).ToArray();
            var index1 = 0;
            var index2 = 0;

            var list = new List<int>(
                list1.Length + 
                list2.Length);

            while (index1 < list1.Length 
                || index2 < list2.Length)
            {
                if (index1 < list1.Length && 
                   (index2 >= list2.Length || list1[index1] <= list2[index2]))
                {
                    list.Add(list1[index1]);
                    index1++;
                }
                else
                {
                    list.Add(list2[index2]);
                    index2++;
                }
            }

            return list;
        }

        private IEnumerable<int> Enumarate(TreeNode node)
        {
            if (node?.left != null)
            {
                foreach (var item in Enumarate(node.left))
                {
                    yield return item;
                }
            }

            if (node != null)
            {
                yield return node.val;
            }

            if (node?.right != null)
            {
                foreach (var item in Enumarate(node.right))
                {
                    yield return item;
                }
            }

            yield break;
        }
    }
}
