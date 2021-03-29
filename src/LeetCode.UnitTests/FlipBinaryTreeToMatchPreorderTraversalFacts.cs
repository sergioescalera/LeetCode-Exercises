using LeetCode.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0971. Flip Binary Tree To Match Preorder Traversal")]
    public class FlipBinaryTreeToMatchPreorderTraversalFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new FlipBinaryTreeToMatchPreorderTraversal();

            var result = sol.FlipMatchVoyage(new TreeNode(1, new TreeNode(2)), new[] { 2, 1 });

            CollectionAssert.AreEqual(new[] { -1 }, result.ToArray());
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new FlipBinaryTreeToMatchPreorderTraversal();

            var result = sol.FlipMatchVoyage(new TreeNode(1, new TreeNode(2), new TreeNode(3)), new[] { 1, 3, 2 });

            CollectionAssert.AreEqual(new[] { 1 }, result.ToArray());
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new FlipBinaryTreeToMatchPreorderTraversal();

            var result = sol.FlipMatchVoyage(new TreeNode(1, new TreeNode(2), new TreeNode(3)), new[] { 1, 2, 3 });

            CollectionAssert.AreEqual(Array.Empty<int>(), result.ToArray());
        }

        [TestMethod]
        public void Example4()
        {
            var sol = new FlipBinaryTreeToMatchPreorderTraversal();

            var result = sol.FlipMatchVoyage(
                new TreeNode(1, new TreeNode(2), new TreeNode(3, new TreeNode(4), new TreeNode(5))),
                new[] { 1, 3, 5, 4, 2 });

            CollectionAssert.AreEqual(new[] { 1, 3 }, result.ToArray());
        }
    }
}
