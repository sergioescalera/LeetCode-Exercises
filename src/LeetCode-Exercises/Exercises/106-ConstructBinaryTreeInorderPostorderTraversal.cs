using LeetCode.Attributes;
using LeetCode.Extensions;
using LeetCode.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ConstructBinaryTreeInorderPostorderTraversal
    {
        public static void Run()
        {
            var ex = new ConstructBinaryTreeInorderPostorderTraversal();

            do
            {
                var inorder = ex.ReadNums("Enter in-order");

                if (inorder == null)
                    break;

                var postorder = ex.ReadNums("Enter post-order");

                if (postorder == null)
                    break;

                var tree = ex.BuildTree(inorder, postorder);

                tree.PrintPretty();

                Console.ReadLine();

            } while (true);
        }

        /// <summary>
        /// inorder = [9,3,15,20,7]
        /// postorder = [9,15,7,20,3]
        /// </summary>
        /// <param name="inorder"></param>
        /// <param name="postorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder == null)
                throw new ArgumentNullException();

            if (postorder == null)
                throw new ArgumentNullException();

            return BuildTree(
                inorder, 
                0,
                inorder.Length - 1,
                postorder, 
                postorder.Length - 1);
        }

        private TreeNode BuildTree(
            int[] inorder,
            int start,
            int end, 
            int[] postorder,
            int postEnd)
        {
            if (start > end)
            {
                return null;
            }

            if (start == end)
            {
                return new TreeNode(inorder[start]);
            }

            var value = postorder[postEnd];

            var index = FindNode(inorder, value, start, end);

            var root = new TreeNode(
                value, 
                left: BuildTree(inorder, start, index - 1, postorder, postEnd - 1), 
                right: BuildTree(inorder, index + 1, end, postorder, postEnd - 1));

            return root;
        }

        private int FindNode(int[] inorder, int val, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (inorder[i] == val)
                {
                    return i;
                }
            }

            throw new InvalidOperationException();
        }
    }
}
