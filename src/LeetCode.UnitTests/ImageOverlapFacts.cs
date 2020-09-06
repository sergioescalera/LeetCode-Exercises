using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("835. Image Overlap")]
    public class ImageOverlapFacts
    {
        [TestMethod]
        public void Example1()
        {
            var a = new[] 
            {
                new [] { 1, 1, 0 },
                new [] { 0, 1, 0 },
                new [] { 0, 1, 0 }
            };
            var b = new[] 
            {
                new [] { 0, 0, 0 },
                new [] { 0, 1, 1 },
                new [] { 0, 0, 1 }
            };


            var sol = new ImageOverlap();

            var val = sol.LargestOverlap(a, b);

            Assert.AreEqual(3, val);
        }

        [TestMethod]
        public void Example2()
        {
            var a = new[]
            {
                new [] { 1, 0 },
                new [] { 0, 0 }
            };
            var b = new[]
            {
                new [] { 0, 1 },
                new [] { 1, 0 }
            };

            var sol = new ImageOverlap();

            var val = sol.LargestOverlap(a, b);

            Assert.AreEqual(1, val);
        }
    }
}
