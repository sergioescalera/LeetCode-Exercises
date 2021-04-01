using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0936. Stamping The Sequence")]
    public class StampingTheSequenceFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new StampingTheSequence();

            var result = sol.MovesToStamp("abc", "ababc");

            Assert.AreEqual("0,2", string.Join(",", result));
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new StampingTheSequence();

            var result = sol.MovesToStamp("abca", "aabcaca");

            Assert.AreEqual("0,3,1", string.Join(",", result));
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new StampingTheSequence();

            var result = sol.MovesToStamp("h", "hhhhh");

            Assert.AreEqual("4,3,2,1,0", string.Join(",", result));
        }

        [TestMethod]
        public void Example4()
        {
            var sol = new StampingTheSequence();

            var result = sol.MovesToStamp("uskh", "uskhkhhskh");

            Assert.AreEqual("6,3,2,0", string.Join(",", result));
        }
    }
}
