using LeetCode.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestCategory("206. Reverse Linked List")]
    [TestClass]
    public class ReverseLinkedListFacts
    {
        [TestMethod]
        public void ReverseEmptyList()
        {
            var sol = new ReverseLinkedList();

            Assert.IsNull(sol.ReverseList(null));
        }

        [TestMethod]
        public void ReverseOneNodeList()
        {
            var sol = new ReverseLinkedList();

            var one = sol.ReverseList(new ListNode(100));

            Assert.IsNotNull(one);

            Assert.AreEqual("100", one.ToString());
        }

        [TestMethod]
        public void ReverseTwoNodeList()
        {
            var sol = new ReverseLinkedList();

            var two = sol.ReverseList(new ListNode(100, new ListNode(999)));

            Assert.IsNotNull(two);

            Assert.AreEqual("999, 100", two.ToString());
        }

        [TestMethod]
        public void ReverseThreeNodeList()
        {
            var sol = new ReverseLinkedList();

            var list = sol.ReverseList(
                new ListNode(100, 
                new ListNode(999, 
                new ListNode(-99))));

            Assert.IsNotNull(list);

            Assert.AreEqual("-99, 999, 100", list.ToString());
        }
    }
}
