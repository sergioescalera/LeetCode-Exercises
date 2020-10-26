using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0227. Basic Calculator II")]
    public class BasicCalculatorIIFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new BasicCalculatorII();

            var result = sol.Calculate("3 + 2 * 2");

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new BasicCalculatorII();

            var result = sol.Calculate(" 3/2 ");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new BasicCalculatorII();

            var result = sol.Calculate(" 3+5 / 2 ");

            Assert.AreEqual(5, result);
        }
    }
}
