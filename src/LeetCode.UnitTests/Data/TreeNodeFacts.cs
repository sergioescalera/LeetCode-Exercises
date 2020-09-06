using LeetCode.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("Data - TreeNode")]
    public class TreeNodeFacts
    {
        [TestMethod]
        public void CanCreateDefaultInstance()
        {
            var node = new TreeNode();

            Assert.IsNotNull(node);
            Assert.AreEqual(0, node.val);
            Assert.IsNull(node.left);
            Assert.IsNull(node.right);
        }

        [TestMethod]
        public void CanCreateInstance()
        {
            var node = new TreeNode(3);

            Assert.IsNotNull(node);
            Assert.AreEqual(3, node.val);
            Assert.IsNull(node.left);
            Assert.IsNull(node.right);

            var another = new TreeNode(3, new TreeNode(), new TreeNode(4));

            Assert.IsNotNull(another);
            Assert.AreEqual(3, another.val);
            Assert.IsNotNull(another.left);
            Assert.IsNotNull(another.right);
            Assert.AreEqual(0, another.left.val);
            Assert.AreEqual(4, another.right.val);
        }

        [TestMethod]
        public void EqualLeafNodes()
        {
            Assert.AreEqual(new TreeNode(3), new TreeNode(3));

            Assert.AreNotEqual(new TreeNode(5), new TreeNode(3));
        }

        [TestMethod]
        public void EqualTrees()
        {
            Assert.AreEqual(
                new TreeNode(3, new TreeNode(0)),
                new TreeNode(3, new TreeNode(0)));

            Assert.AreEqual(
                new TreeNode(3, null, new TreeNode(4)),
                new TreeNode(3, null, new TreeNode(4)));

            Assert.AreEqual(
                new TreeNode(3, new TreeNode(1), new TreeNode(4)),
                new TreeNode(3, new TreeNode(1), new TreeNode(4)));
        }

        [TestMethod]
        public void NotEqualTrees()
        {
            Assert.AreNotEqual(
                new TreeNode(3, new TreeNode(0)),
                new TreeNode(3, null, new TreeNode(0)));

            Assert.AreNotEqual(
                new TreeNode(3, new TreeNode(4)),
                new TreeNode(3, null, new TreeNode(4)));

            Assert.AreNotEqual(
                new TreeNode(3, new TreeNode(2), new TreeNode(4)),
                new TreeNode(3, new TreeNode(1), new TreeNode(4)));

            Assert.AreNotEqual(
                new TreeNode(3, new TreeNode(2), new TreeNode(4)),
                new TreeNode(3, new TreeNode(1), new TreeNode(5)));
        }

        [TestMethod]
        public void CloneShouldReturnEqualTree()
        {
            var tree = new TreeNode(3, new TreeNode(2), new TreeNode(4));

            var clone = tree.Clone() as TreeNode;

            Assert.IsNotNull(clone);
            Assert.IsFalse(clone == tree);
            Assert.AreEqual(tree, clone);
        }
    }
}
