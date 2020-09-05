using LeetCode.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("1305. All Elements in Two Binary Search Trees")]
    public class AllElementsTwoBSTFacts
    {
        [TestMethod]
        public void EmptyTrees()
        {
            var sol = new AllElementsTwoBST();

            var merged = sol.GetAllElements(null, null);

            Assert.IsNotNull(merged);
            Assert.IsFalse(merged.Any());
        }

        [TestMethod]
        public void EmptyTree()
        {
            var sol = new AllElementsTwoBST();

            CollectionAssert.AreEqual(
                new[] { -99 },
                sol.GetAllElements(new TreeNode(-99), null).ToArray());

            CollectionAssert.AreEqual(
                new[] { 99 },
                sol.GetAllElements(null, new TreeNode(99)).ToArray());

            CollectionAssert.AreEqual(
                new[] { -10, 0, 10 },
                sol.GetAllElements(
                    null, 
                    new TreeNode(0, new TreeNode(-10), new TreeNode(10))).ToArray());

            CollectionAssert.AreEqual(
                new[] { -10, 0, 10 },
                sol.GetAllElements(
                    new TreeNode(0, new TreeNode(-10), new TreeNode(10)),
                    null).ToArray());
        }

        [TestMethod]
        public void SameElements()
        {
            var sol = new AllElementsTwoBST();

            CollectionAssert.AreEqual(
                new[] { 1, 1, 8, 8 },
                sol.GetAllElements(
                new TreeNode(1, null, new TreeNode(8)),
                new TreeNode(8, new TreeNode(1), null)).ToList());
        }

        [TestMethod]
        public void DiffElements()
        {
            var sol = new AllElementsTwoBST();

            CollectionAssert.AreEqual(
                new[] { 1, 2, 8, 9, 10 },
                sol.GetAllElements(
                    new TreeNode(1, null, new TreeNode(9)),
                    new TreeNode(8, new TreeNode(2), new TreeNode(10))).ToArray());

            CollectionAssert.AreEqual(
                new[] { 1, 2, 8, 9, 10 },
                sol.GetAllElements(
                    new TreeNode(8, new TreeNode(2), new TreeNode(10)),
                    new TreeNode(1, null, new TreeNode(9))).ToArray());

            CollectionAssert.AreEqual(
                new[] { 0, 1, 1, 2, 3, 4 },
                sol.GetAllElements(
                    new TreeNode(2, new TreeNode(1), new TreeNode(4)),
                    new TreeNode(1, new TreeNode(0), new TreeNode(3))).ToArray());

            CollectionAssert.AreEqual(
                new[] { -10, 0, 0, 1, 2, 5, 7, 10 },
                sol.GetAllElements(
                    new TreeNode(0, new TreeNode(-10), new TreeNode(10)),
                    new TreeNode(5, new TreeNode(1, new TreeNode(0), new TreeNode(2)), new TreeNode(7))).ToArray());

            CollectionAssert.AreEqual(
                new[] { -10, 0, 0, 1, 2, 5, 7, 10 },
                sol.GetAllElements(
                    new TreeNode(5, new TreeNode(1, new TreeNode(0), new TreeNode(2)), new TreeNode(7)),
                    new TreeNode(0, new TreeNode(-10), new TreeNode(10))).ToArray());
        }
    }
}
