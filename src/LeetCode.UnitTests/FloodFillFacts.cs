using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LeetCode.UnitTests
{
    [TestCategory("733. Flood Fill")]
    [TestClass]
    public class FloodFillFacts
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowWhenNullImage()
        {
            var sol = new FloodFillSolution();

            sol.FloodFill(null, 0, 0, 0);
        }

        [TestMethod]
        public void TestCase1x1()
        {
            var sol = new FloodFillSolution();
            var img = new[]
            {
                new [] { 1 }
            };

            sol.FloodFill(img, 0, 0, 2);

            var expected = new[]
            {
                new [] { 2 }
            };

            Assert.AreEqual(expected.Length, img.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[0], img[0]);
            }
        }

        [TestMethod]
        public void TestCase1x5()
        {
            var sol = new FloodFillSolution();
            var img = new[]
            {
                new [] { 1, 1, 0, 2, 3 }
            };

            sol.FloodFill(img, 0, 0, 2);

            var expected = new[]
            {
                new [] { 2, 2, 0, 2, 3 }
            };

            Assert.AreEqual(expected.Length, img.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[0], img[0]);
            }
        }

        [TestMethod]
        public void TestCase2x2()
        {
            var sol = new FloodFillSolution();
            var img = new[]
            {
                new [] { 1, 1 },
                new [] { 1, 1 }
            };

            sol.FloodFill(img, 1, 1, 2);

            var expected = new[]
            {
                new [] { 2, 2 },
                new [] { 2, 2 }
            };

            Assert.AreEqual(expected.Length, img.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[0], img[0]);
            }
        }

        [TestMethod]
        public void TestCase3x3()
        {
            var sol = new FloodFillSolution();
            var img = new[]
            {
                new [] { 1, 1, 1 },
                new [] { 1, 1, 0 },
                new [] { 1, 0, 1 }
            };
            
            sol.FloodFill(img, 1, 1, 2);

            var expected = new[]
            {
                new [] { 2, 2, 2 },
                new [] { 2, 2, 0 },
                new [] { 2, 0, 1 }
            };

            Assert.AreEqual(expected.Length, img.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[0], img[0]);
            }
        }

        [TestMethod]
        public void AvoidInfiniteLoop()
        {
            var sol = new FloodFillSolution();
            var img = new[]
            {
                new [] { 0, 0, 0 },
                new [] { 0, 1, 1 }
            };

            sol.FloodFill(img, 1, 1, 1);

            var expected = new[]
            {
                new [] { 0, 0, 0 },
                new [] { 0, 1, 1 }
            };

            Assert.AreEqual(expected.Length, img.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[0], img[0]);
            }
        }
    }
}
