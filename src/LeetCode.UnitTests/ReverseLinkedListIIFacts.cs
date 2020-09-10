using LeetCode.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0092. Reverse Linked List II")]
    public class ReverseLinkedListIIFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new ReverseLinkedListII();
            var list = new ListNode(
                1,
                new ListNode(2,
                new ListNode(3,
                new ListNode(4,
                new ListNode(5)))));

            var reversed = sol.ReverseBetween(list, 2, 4);

            Assert.AreEqual("1, 4, 3, 2, 5", reversed.ToString());
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new ReverseLinkedListII();
            var list = new ListNode(
                1,
                new ListNode(2,
                new ListNode(3,
                new ListNode(4,
                new ListNode(5)))));

            var reversed = sol.ReverseBetween(list, 6, 7);

            Assert.AreEqual("1, 2, 3, 4, 5", reversed.ToString());
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new ReverseLinkedListII();
            var list = new ListNode(
                1,
                new ListNode(2,
                new ListNode(3)));

            var reversed = sol.ReverseBetween(list, 1, 3);

            Assert.AreEqual("3, 2, 1", reversed.ToString());
        }

        [TestMethod]
        public void Example4()
        {
            var sol = new ReverseLinkedListII();
            var list = new ListNode(
                1,
                new ListNode(2,
                new ListNode(3)));

            var reversed = sol.ReverseBetween(list, 1, 2);

            Assert.AreEqual("2, 1, 3", reversed.ToString());
        }

        [TestMethod]
        public void Example5()
        {
            var sol = new ReverseLinkedListII();
            var list = new ListNode(
                1,
                new ListNode(2,
                new ListNode(3)));

            var reversed = sol.ReverseBetween(list, 2, 3);

            Assert.AreEqual("1, 3, 2", reversed.ToString());
        }

        [TestMethod]
        public void Example6()
        {
            var sol = new ReverseLinkedListII();
            var list = new ListNode(
                1,
                new ListNode(2,
                new ListNode(3)));

            var reversed = sol.ReverseBetween(list, 2, 4);

            Assert.AreEqual("1, 3, 2", reversed.ToString());
        }

        [TestMethod]
        public void Example7()
        {
            var sol = new ReverseLinkedListII();
            var list = new ListNode(
                1,
                new ListNode(2,
                new ListNode(3,
                new ListNode(4))));

            var reversed = sol.ReverseBetween(list, 2, 4);

            Assert.AreEqual("1, 4, 3, 2", reversed.ToString());
        }
    }
}
