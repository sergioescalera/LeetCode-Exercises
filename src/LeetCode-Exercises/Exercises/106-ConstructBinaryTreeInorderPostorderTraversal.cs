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
                0,
                postorder.Length - 1);
        }

        private TreeNode BuildTree(
            int[] inorder,
            int start,
            int end, 
            int[] postorder,
            int postStart,
            int postEnd)
        {
            if (start > end)
            {
                return null;
            }

            var value = postorder[postEnd];

            var index = FindNode(inorder, start, end, v => v == value);

            var postLeft = postEnd - 1;

            while (FindNode(inorder, start, index - 1, v => v == postorder[postLeft]) < 0
                && postLeft > 0)
            {
                postLeft--;
            }

            var left = BuildTree(inorder, start, index - 1, postorder, postStart, postLeft);

            var right = BuildTree(inorder, index + 1, end, postorder, postLeft + 1, postEnd - 1);

            var root = new TreeNode(
                value, 
                left: left, 
                right: right);

            return root;
        }

        private int FindNode(int[] inorder, int start, int end, Func<int, bool> func)
        {
            for (int i = start; i <= end; i++)
            {
                if (func(inorder[i]))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
