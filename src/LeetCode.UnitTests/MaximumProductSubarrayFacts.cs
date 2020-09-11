using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestCategory("0152. Maximum Product Subarray")]
    [TestClass]
    public class MaximumProductSubarrayFacts
    {
        [TestMethod]
        public void ShouldReturn0WhenNullOrEmpty()
        {
            var sol = new MaximumProductSubarray();

            Assert.AreEqual(0, sol.MaxProduct(null));
            Assert.AreEqual(0, sol.MaxProduct(new int[0]));
        }

        [TestMethod]
        public void ShouldReturnSingleValue()
        {
            var sol = new MaximumProductSubarray();

            Assert.AreEqual(99, sol.MaxProduct(new[] { 99 }));
            Assert.AreEqual(-99, sol.MaxProduct(new int[] { -99 }));
        }

        [TestMethod]
        public void Example1()
        {
            var sol = new MaximumProductSubarray();

            Assert.AreEqual(6, sol.MaxProduct(new[] { 2, 3, -2, 4 }));
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new MaximumProductSubarray();

            Assert.AreEqual(0, sol.MaxProduct(new[] { -2, 0, -1 }));
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new MaximumProductSubarray();

            Assert.AreEqual(0, sol.MaxProduct(new[] { 0 ,0, -2, 0 }));
        }

        [TestMethod]
        public void Example4()
        {
            var sol = new MaximumProductSubarray();

            Assert.AreEqual(6, sol.MaxProduct(new[] { -1, -2, -3 }));
        }
    }
}
