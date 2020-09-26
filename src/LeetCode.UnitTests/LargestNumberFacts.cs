using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0179. Largest Number")]
    public class LargestNumberFacts
    {
        [TestMethod]
        public void Example0()
        {
            var sol = new LargestNumberSolution();

            Assert.AreEqual("123", sol.LargestNumber(new[] { 123 }));

            Assert.AreEqual("", sol.LargestNumber(new int[] { }));
        }

        [TestMethod]
        public void Example1()
        {
            var sol = new LargestNumberSolution();

            Assert.AreEqual("210", sol.LargestNumber(new[] { 10, 2 }));
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new LargestNumberSolution();

            Assert.AreEqual("9534330", sol.LargestNumber(new[] { 3, 30, 34, 5, 9 }));
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new LargestNumberSolution();

            Assert.AreEqual(
                "9995929190954321", 
                sol.LargestNumber(new[] { 91, 92, 909, 99, 95, 5, 1, 2, 3, 4 }));
        }

        [TestMethod]
        public void Example4()
        {
            var sol = new LargestNumberSolution();

            Assert.AreEqual(
                "12121",
                sol.LargestNumber(new[] { 121, 12 }));
        }

        [TestMethod]
        public void Example5()
        {
            var sol = new LargestNumberSolution();

            Assert.AreEqual(
                "0",
                sol.LargestNumber(new[] { 0, 0 }));
        }
    }
}
