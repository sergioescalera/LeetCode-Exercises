using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("128. Longest Consecutive Sequence")]
    public class LongestConsecutiveSequenceFacts
    {
        [TestMethod]
        public void ShouldReturn0()
        {
            var sol = new LongestConsecutiveSequence();

            Assert.AreEqual(0, sol.LongestConsecutive(new int[0]));

            Assert.AreEqual(0, sol.LongestConsecutive(null));
        }

        [TestMethod]
        public void ShouldReturn1()
        {
            var sol = new LongestConsecutiveSequence();

            Assert.AreEqual(1, sol.LongestConsecutive(new[] { 0 }));

            Assert.AreEqual(1, sol.LongestConsecutive(new[] { 1 }));

            Assert.AreEqual(1, sol.LongestConsecutive(new[] { 10 }));

            Assert.AreEqual(1, sol.LongestConsecutive(new[] { int.MaxValue }));

            Assert.AreEqual(1, sol.LongestConsecutive(new[] { 1, 1, 1 }));

            Assert.AreEqual(1, sol.LongestConsecutive(new[] { 0, 0 }));
        }

        [TestMethod]
        public void ShouldReturn4()
        {
            var sol = new LongestConsecutiveSequence();

            Assert.AreEqual(4, sol.LongestConsecutive(new[] { 100, 4, 200, 1, 3, 2, 1, 2, 4 }));
        }
    }
}
