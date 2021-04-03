using LeetCode.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("LRU Cache")]
    public class LRUCacheFacts
    {
        [TestMethod]
        public void Example1()
        {
            var cache = new LRUCache<int, int>(2, -1);

            cache.Put(2, 1);
            cache.Put(2, 2);

            Assert.AreEqual(2, cache.Get(2));

            cache.Put(1, 1);
            cache.Put(4, 1);

            Assert.AreEqual(-1, cache.Get(2));
        }
    }
}
