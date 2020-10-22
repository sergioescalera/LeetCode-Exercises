using LeetCode.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0109. Convert Sorted List to Binary Search Tree")]
    public class ConvertSortedListToBinarySearchTreeFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new ConvertSortedListToBinarySearchTree();
            var tree = sol.SortedListToBST(new ListNode("-10 -3 0 5 9"));

            Assert.IsNotNull(tree);
        }
    }
}
