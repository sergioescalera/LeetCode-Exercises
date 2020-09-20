using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("1291. Sequential Digits")]
    public class SequentialDigitsFacts
    {
        [TestMethod]
        public void Example1()
        {
            CollectionAssert.AreEquivalent(
                new[] { 123, 234 },
                new SequentialDigitsSolution().SequentialDigits(100, 300).ToArray());
        }

        [TestMethod]
        public void Example2()
        {
            CollectionAssert.AreEquivalent(
                new[] { 1234, 2345, 3456, 4567, 5678, 6789, 12345 },
                new SequentialDigitsSolution().SequentialDigits(1000, 13000).ToArray());
        }
    }
}
