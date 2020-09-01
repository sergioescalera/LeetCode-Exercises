using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("441. Arranging Coins")]
    public class ArrangingCoinsFacts
    {
        [TestMethod]
        public void ShouldReturnMinus1()
        {
            var sol = new ArrangingCoins();

            Assert.AreEqual(-1, sol.ArrangeCoins(-1));

            Assert.AreEqual(-1, sol.ArrangeCoins(-10));

            Assert.AreEqual(-1, sol.ArrangeCoins(int.MinValue));
        }

        [TestMethod]
        public void ShouldReturn0()
        {
            var sol = new ArrangingCoins();

            Assert.AreEqual(0, sol.ArrangeCoins(0));
        }

        [TestMethod]
        public void ShouldReturn1()
        {
            var sol = new ArrangingCoins();

            Assert.AreEqual(1, sol.ArrangeCoins(1));
            Assert.AreEqual(1, sol.ArrangeCoins(2));
        }

        [TestMethod]
        public void ShouldReturn2()
        {
            var sol = new ArrangingCoins();

            Assert.AreEqual(2, sol.ArrangeCoins(3));
            Assert.AreEqual(2, sol.ArrangeCoins(4));
            Assert.AreEqual(2, sol.ArrangeCoins(5));
        }

        [TestMethod]
        public void ShouldReturn3()
        {
            var sol = new ArrangingCoins();

            Assert.AreEqual(3, sol.ArrangeCoins(6));
            Assert.AreEqual(3, sol.ArrangeCoins(7));
            Assert.AreEqual(3, sol.ArrangeCoins(8));
            Assert.AreEqual(3, sol.ArrangeCoins(9));
        }

        [TestMethod]
        public void ShouldReturn4()
        {
            var sol = new ArrangingCoins();

            Assert.AreEqual(4, sol.ArrangeCoins(10));
            Assert.AreEqual(4, sol.ArrangeCoins(11));
            Assert.AreEqual(4, sol.ArrangeCoins(12));
            Assert.AreEqual(4, sol.ArrangeCoins(13));
            Assert.AreEqual(4, sol.ArrangeCoins(14));
        }

        [TestMethod]
        public void ShouldReturn5()
        {
            var sol = new ArrangingCoins();

            Assert.AreEqual(5, sol.ArrangeCoins(15));
        }

        [TestMethod]
        public void ShouldReturn99()
        {
            var sol = new ArrangingCoins();

            Assert.AreEqual(99, sol.ArrangeCoins(5000));
            Assert.AreEqual(99, sol.ArrangeCoins(5001));
            Assert.AreEqual(99, sol.ArrangeCoins(5002));
            Assert.AreEqual(99, sol.ArrangeCoins(5003));
            Assert.AreEqual(99, sol.ArrangeCoins(5004));
            Assert.AreEqual(99, sol.ArrangeCoins(5005));
            Assert.AreEqual(99, sol.ArrangeCoins(5006));
            Assert.AreEqual(99, sol.ArrangeCoins(5007));
        }
    }
}
