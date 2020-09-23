using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("1094. Car Pooling")]
    public class CarPoolingFacts
    {
        [TestMethod]
        public void Example1()
        {
            Assert.IsFalse(
                new CarPoolingSolution().CarPooling(
                    new [] { new[] { 2, 1, 5 }, new[] { 3, 3, 7 } }, 4));
        }

        [TestMethod]
        public void Example2()
        {
            Assert.IsTrue(
                new CarPoolingSolution().CarPooling(
                    new[] { new[] { 2, 1, 5 }, new[] { 3, 3, 7 } }, 5));
        }

        [TestMethod]
        public void Example3()
        {
            Assert.IsFalse(
                new CarPoolingSolution().CarPooling(
                    new[]
                    {
                        new [] { 3, 3, 5 },
                        new [] { 4, 5, 6 },
                        new [] { 1, 2, 7 },
                        new [] { 3, 2, 8 },
                        new [] { 10, 5, 9 },
                        new [] { 2, 5, 9 },
                        new [] { 1, 2, 5 }
                    }, 19));
        }

    }
}
