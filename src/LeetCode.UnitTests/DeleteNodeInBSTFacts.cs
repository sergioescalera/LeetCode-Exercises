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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowErrorWhenNullNode()
        {
            new DeleteNodeInBST().DeleteNode(null, 0);
        }

        [TestMethod]
        public void ReturnSameTreeIfNotFound()
        {
            var tree = new TreeNode(3);
            var clone = tree.Clone();

            var deleted = new DeleteNodeInBST().DeleteNode(tree, 0);

            Assert.AreEqual(clone, deleted);
        }
    }
}
