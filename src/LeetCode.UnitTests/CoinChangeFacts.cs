using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0322. Coin Change")]
    public class CoinChangeFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new CoinChangeSolution();

            Assert.AreEqual(3, sol.CoinChange(new[] { 1, 2, 5 }, 11));
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new CoinChangeSolution();

            Assert.AreEqual(-1, sol.CoinChange(new[] { 2 }, 3));
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new CoinChangeSolution();

            Assert.AreEqual(3, sol.CoinChange(new[] { 1, 3, 5 }, 9));
        }

        [TestMethod]
        public void Example4()
        {
            var sol = new CoinChangeSolution();

            Assert.AreEqual(
                26, 
                sol.CoinChange(new[] { 346, 29, 395, 188, 155, 109 }, 9401));
        }

        [TestMethod]
        public void Example5()
        {
            var sol = new CoinChangeSolution();

            Assert.AreEqual(
                18,
                sol.CoinChange(
                    new[] { 52, 480, 116, 409, 170, 240, 496 }, 
                    8230));
        }
    }
}
