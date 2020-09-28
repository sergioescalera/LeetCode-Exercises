using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0713. Subarray Product Less Than K")]
    public class SubarrayProductLessThanKFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new SubarrayProductLessThanK();
            
            Assert.AreEqual(8, sol.NumSubarrayProductLessThanK(new[] { 10, 5, 2, 6 }, 100));
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new SubarrayProductLessThanK();
            
            Assert.AreEqual(0, sol.NumSubarrayProductLessThanK(new[] { 1, 1, 1 }, 1));
            Assert.AreEqual(6, sol.NumSubarrayProductLessThanK(new[] { 1, 1, 1 }, 2));
            Assert.AreEqual(4, sol.NumSubarrayProductLessThanK(new[] { 1, 2, 3 }, 6));
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new SubarrayProductLessThanK();

            Assert.AreEqual(18, sol.NumSubarrayProductLessThanK(new[] { 10, 9, 10, 4, 3, 8, 3, 3, 6, 2, 10, 10, 9, 3 }, 19));
        }

        [TestMethod]
        public void Example4()
        {
            var sol = new SubarrayProductLessThanK();

            Assert.AreEqual(31, 
                sol.NumSubarrayProductLessThanK(new[] { 10, 2, 2, 5, 4, 4, 4, 3, 7, 7 }, 289));
        }

        [TestMethod]
        public void Example5()
        {
            var sol = new SubarrayProductLessThanK();

            Assert.AreEqual(32,
                sol.NumSubarrayProductLessThanK(
                    new[] { 7, 6, 8, 4, 9, 3, 2, 10, 7, 9, 9, 6, 3 }, 236));
        }
    }
}
