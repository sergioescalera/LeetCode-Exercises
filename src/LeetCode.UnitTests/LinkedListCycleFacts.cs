using LeetCode.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestCategory("0141. Linked List Cycle")]
    [TestClass]
    public class LinkedListCycleFacts
    {
        [TestMethod]
        public void OneElem()
        {
            var sol = new LinkedListCycle();

            var head = new ListNode(1);

            Assert.IsFalse(sol.HasCycle(head));

            head.next = head;

            Assert.IsTrue(sol.HasCycle(head));
        }

        [TestMethod]
        public void TwoElem()
        {
            var sol = new LinkedListCycle();

            var head = new ListNode(1, new ListNode(2));

            Assert.IsFalse(sol.HasCycle(head));

            head.next.next = head;

            Assert.IsTrue(sol.HasCycle(head));

            head.next.next = head.next;

            Assert.IsTrue(sol.HasCycle(head));
        }

        [TestMethod]
        public void ThreeElem()
        {
            var sol = new LinkedListCycle();

            var head = new ListNode(1, new ListNode(2, new ListNode(3)));

            Assert.IsFalse(sol.HasCycle(head));

            head.next.next.next = head;

            Assert.IsTrue(sol.HasCycle(head));

            head.next.next.next = head.next;

            Assert.IsTrue(sol.HasCycle(head));

            head.next.next.next = head.next.next;

            Assert.IsTrue(sol.HasCycle(head));
        }
    }
}
