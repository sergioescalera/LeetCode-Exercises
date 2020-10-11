using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("1081. Smallest Subsequence of Distinct Characters")]
    public class SmallestSubsequenceDistinctCharsFacts
    {
        [TestMethod]
        public void Example1()
        {
            Assert.AreEqual(
                "abc",
                new SmallestSubsequenceDistinctChars().SmallestSubsequence("bcabc"));
        }

        [TestMethod]
        public void Example2()
        {
            Assert.AreEqual(
                "acdb", 
                new SmallestSubsequenceDistinctChars().SmallestSubsequence("cbacdcbc"));
        }
    }
}
