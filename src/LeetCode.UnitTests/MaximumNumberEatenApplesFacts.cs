using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("1705. Maximum Number of Eaten Apples")]
    public class MaximumNumberEatenApplesFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new MaximumNumberEatenApples();

            var actual = sol.EatenApples(new[] { 1, 2, 3, 5, 2 }, new[] { 3, 2, 1, 4, 2 });

            var expected = 7;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new MaximumNumberEatenApples();

            var actual = sol.EatenApples(new[] { 3, 0, 0, 0, 0, 2 }, new[] { 3, 0, 0, 0, 0, 2 });

            var expected = 5;

            Assert.AreEqual(expected, actual);
        }
    }
}
