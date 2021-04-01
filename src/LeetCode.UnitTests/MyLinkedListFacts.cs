using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0707. Design Linked List")]
    public class MyLinkedListFacts
    {
        [TestMethod]
        public void Example1()
        {
            var myLinkedList = new MyLinkedList();

            myLinkedList.AddAtHead(1);
            myLinkedList.AddAtTail(3);
            myLinkedList.AddAtIndex(1, 2);

            Assert.AreEqual(3, myLinkedList.Get(2));

            myLinkedList.DeleteAtIndex(1);

            Assert.AreEqual(3, myLinkedList.Get(1));
        }

        [TestMethod]
        public void Example2()
        {   
            var myLinkedList = new MyLinkedList();

            myLinkedList.AddAtIndex(0, 10);
            myLinkedList.AddAtIndex(0, 20);
            myLinkedList.AddAtIndex(1, 30);

            Assert.AreEqual(20, myLinkedList.Get(0));
        }
    }
}
