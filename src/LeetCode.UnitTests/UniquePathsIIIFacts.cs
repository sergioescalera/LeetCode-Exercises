using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("980. Unique Paths III")]
    public class UniquePathsIIIFacts
    {
        [TestMethod]
        public void Example0()
        {
            Assert.AreEqual(
                0,
                new UniquePathsIIISolution().UniquePathsIII(new[]
                {
                    new[] { 1, 0 },
                    new[] { 0, 2 }
                }));

            Assert.AreEqual(
                1,
                new UniquePathsIIISolution().UniquePathsIII(new[]
                {
                    new[] { 1, 0 },
                    new[] { 2, 0 }
                }));

            Assert.AreEqual(
                1,
                new UniquePathsIIISolution().UniquePathsIII(new[]
                {
                    new[] { 1, 0, 2 }
                }));

            Assert.AreEqual(
                0,
                new UniquePathsIIISolution().UniquePathsIII(new[]
                {
                    new[] { 1, -1, 2 }
                }));
        }

        [TestMethod]
        public void Example1()
        {
            Assert.AreEqual(
                2,
                new UniquePathsIIISolution().UniquePathsIII(new []
                {
                    new[] { 1, 0, 0, 0 },
                    new[] { 0, 0, 0, 0 },
                    new[] { 0, 0, 2, -1 }
                }));
        }

        [TestMethod]
        public void Example2()
        {
            Assert.AreEqual(
                4,
                new UniquePathsIIISolution().UniquePathsIII(new[]
                {
                    new[] { 1, 0, 0, 0 },
                    new[] { 0, 0, 0, 0 },
                    new[] { 0, 0, 0, 2 }
                }));
        }
    }
}
