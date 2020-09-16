using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0421. Maximum XOR of Two Numbers in an Array")]
    public class MaxXOROfTwoNumbersFacts
    {
        [TestMethod]
        public void Example0()
        {
            var sol = new MaxXOROfTwoNumbers();

            var value = sol.FindMaximumXOR(new[] { 0, int.MaxValue });

            Assert.AreEqual(int.MaxValue, value);
        }

        [TestMethod]
        public void Example1()
        {
            var sol = new MaxXOROfTwoNumbers();

            var value = sol.FindMaximumXOR(new[] { 3, 10, 5, 25, 2, 8 });

            Assert.AreEqual(28, value);
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new MaxXOROfTwoNumbers();

            var value = sol.FindMaximumXOR(new[] { 15, 15, 9, 3, 2 });

            Assert.AreEqual(13, value);
        }
    }
}
