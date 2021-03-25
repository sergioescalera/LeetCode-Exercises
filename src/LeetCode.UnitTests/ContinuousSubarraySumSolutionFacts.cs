using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0523. Continuous Subarray Sum")]
    public class ContinuousSubarraySumSolutionFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new ContinuousSubarraySumSolution();

            var result = sol.CheckSubarraySum(new[] { 23, 2, 4, 6, 7 }, 6);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new ContinuousSubarraySumSolution();

            var result = sol.CheckSubarraySum(new[] { 23, 2, 6, 4, 7 }, 6);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new ContinuousSubarraySumSolution();

            var result = sol.CheckSubarraySum(new[] { 1, 2, 3 }, 6);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Example4()
        {
            var sol = new ContinuousSubarraySumSolution();

            var result = sol.CheckSubarraySum(new[] { 1, 2, 3 }, 7);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Example5()
        {
            var sol = new ContinuousSubarraySumSolution();

            var result = sol.CheckSubarraySum(new[] { 1, 2, 3 }, 4);

            Assert.IsFalse(result);
        }
    }
}
