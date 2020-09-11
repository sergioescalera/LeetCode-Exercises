using LeetCode.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0328. Odd Even Linked List")]
    public class OddEvenLinkedListFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new OddEvenLinkedList();

            Assert.AreEqual("1", sol
                .OddEvenList(new ListNode(1)).ToString());

            Assert.AreEqual("1, 2", sol
                .OddEvenList(new ListNode(1, new ListNode(2))).ToString());
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new OddEvenLinkedList();

            Assert.AreEqual(
                "1, 3, 2", 
                sol.OddEvenList(new ListNode("1, 2, 3")).ToString());

            Assert.AreEqual(
                "1, 3, 2, 4", 
                sol.OddEvenList(new ListNode("1, 2, 3, 4")).ToString());
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new OddEvenLinkedList();

            Assert.AreEqual(
                "1, 3, 5, 2, 4",
                sol.OddEvenList(new ListNode("1, 2, 3, 4, 5")).ToString());

            Assert.AreEqual(
                "1, 3, 5, 2, 4, 6", 
                sol.OddEvenList(new ListNode("1 2 3 4 5 6")).ToString());
        }
    }
}
