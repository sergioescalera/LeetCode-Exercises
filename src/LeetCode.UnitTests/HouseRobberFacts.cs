﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("198. House Robber")]
    public class HouseRobberFacts
    {
        [TestMethod]
        public void Empty()
        {
            var sol = new HouseRobber();

            Assert.AreEqual(0, sol.Rob(null));
            Assert.AreEqual(0, sol.Rob(new int[0]));
        }

        [TestMethod]
        public void OneHouse()
        {
            var sol = new HouseRobber();

            Assert.AreEqual(1, sol.Rob(new int[] { 1 }));
            Assert.AreEqual(10, sol.Rob(new int[] { 10 }));
        }

        [TestMethod]
        public void TwoHouses()
        {
            var sol = new HouseRobber();

            Assert.AreEqual(2, sol.Rob(new int[] { 1,2 }));
            Assert.AreEqual(10, sol.Rob(new int[] { 10, 9 }));
        }

        [TestMethod]
        public void ThreeHouses()
        {
            var sol = new HouseRobber();

            Assert.AreEqual(4, sol.Rob(new int[] { 1, 3, 3 }));
            Assert.AreEqual(21, sol.Rob(new int[] { 10, 21, 10 }));
        }

        [TestMethod]
        public void FourHouses()
        {
            var sol = new HouseRobber();

            Assert.AreEqual(24, sol.Rob(new int[] { 1, 3, 3, 21 }));
            Assert.AreEqual(23, sol.Rob(new int[] { 10, 21, 13, 1 }));
            Assert.AreEqual(104, sol.Rob(new int[] { 5, 1, 98, 99 }));
        }
    }
}
