using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0123. Best Time to Buy and Sell Stock III")]
    public class BestTimeToBuyAndSellStockIIIFacts
    {
        [TestMethod]
        public void Example0()
        {
            var sol = new BestTimeToBuyAndSellStockIII();

            var profit = sol.MaxProfit(new[] { 1, 10, 5, 1, 10, 5, 1, 10 });

            Assert.AreEqual(18, profit);
        }

        [TestMethod]
        public void Example1()
        {
            var sol = new BestTimeToBuyAndSellStockIII();

            var profit = sol.MaxProfit(new[] { 3, 3, 5, 0, 0, 3, 1, 4 });

            Assert.AreEqual(6, profit);
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new BestTimeToBuyAndSellStockIII();

            var profit = sol.MaxProfit(new[] { 1, 2, 3, 4, 5 });

            Assert.AreEqual(4, profit);
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new BestTimeToBuyAndSellStockIII();

            var profit = sol.MaxProfit(new[] { 7, 6, 4, 3, 1 });

            Assert.AreEqual(0, profit);
        }
    }
}
