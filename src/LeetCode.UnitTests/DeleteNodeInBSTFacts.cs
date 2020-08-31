using System;
using LeetCode.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("450. Delete Node in a BST")]
    public class DeleteNodeInBSTFacts
    {
        [TestMethod]
        public void CanCreateInstance()
        {
            new DeleteNodeInBST();
        }

        [TestMethod]
        public void ReturnNullWhenNullNode()
        {
            Assert.IsNull(new DeleteNodeInBST().DeleteNode(null, 0));
        }

        [TestMethod]
        public void ReturnSameIfNotFound()
        {
            var solution = new DeleteNodeInBST();

            var tree = new TreeNode(3);
            var clone = tree.Clone();

            Assert.AreEqual(clone, solution.DeleteNode(tree, 0));

            Assert.AreEqual(clone, solution.DeleteNode(tree, 5));
        }

        [TestMethod]
        public void ShouldRemoveLeafNode()
        {
            var solution = new DeleteNodeInBST();

            Assert.AreEqual(
                new TreeNode(3), 
                solution.DeleteNode(new TreeNode(3, new TreeNode(2)), 2));

            Assert.AreEqual(
                new TreeNode(3),
                solution.DeleteNode(new TreeNode(3, null, new TreeNode(5)), 5));
        }

        [TestMethod]
        public void ShouldRemoveNonLeafNode()
        {
            var solution = new DeleteNodeInBST();

            var tree = new TreeNode(
                5,
                new TreeNode(3, new TreeNode(2), new TreeNode(4)),
                new TreeNode(6, null, new TreeNode(7)));

            var deleted = solution.DeleteNode(tree, 3);
            var expected1 = new TreeNode(
                5,
                new TreeNode(2, null, new TreeNode(4)),
                new TreeNode(6, null, new TreeNode(7)));

            var expected2 = new TreeNode(
                5,
                new TreeNode(4, new TreeNode(2)),
                new TreeNode(6, null, new TreeNode(7)));

            Assert.IsTrue(deleted.Equals(expected1) || deleted.Equals(expected2));
        }
    }
}
