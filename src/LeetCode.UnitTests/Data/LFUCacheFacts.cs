using LeetCode.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("LFU Cache")]
    public class LFUCacheFacts
    {
        [TestMethod]
        public void Example1()
        {
            var lfu = new LFUCache<int, int>(2, @default: -1);

            lfu.Put(1, 1);
            lfu.Put(2, 2);

            Assert.AreEqual(1, lfu.Get(1));
                             
            lfu.Put(3, 3);
                          
            Assert.AreEqual(-1, lfu.Get(2));

            Assert.AreEqual(3, lfu.Get(3));
                             
            lfu.Put(4, 4);
                          
            Assert.AreEqual(-1, lfu.Get(1));
            Assert.AreEqual(3, lfu.Get(3));
                          
            Assert.AreEqual(4, lfu.Get(4));
        }

        [TestMethod]
        public void Example2()
        {
            var lfu = new LFUCache<int, int>(3, -1);

            lfu.Put(2, 2);
            lfu.Put(1, 1);

            Assert.AreEqual(2, lfu.Get(2));
            Assert.AreEqual(1, lfu.Get(1));
            Assert.AreEqual(2, lfu.Get(2));

            lfu.Put(3, 3);
            lfu.Put(4, 4);

            Assert.AreEqual(-1, lfu.Get(3));
            Assert.AreEqual(2, lfu.Get(2));
            Assert.AreEqual(1, lfu.Get(1));
            Assert.AreEqual(4, lfu.Get(4));
        }

        [TestMethod]
        public void Example3()
        {
            var lfu = new LFUCache<int, int>(0, -1);

            lfu.Put(0, 0);

            Assert.AreEqual(-1, lfu.Get(0));
        }
    }
}
