using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("295. Find Median from Data Stream")]
    public class FindMedianFromDataStreamFacts
    {
        [TestMethod]
        public void Example1()
        {
            var finder = new MedianFinder();

            finder.AddNum(1);

            Assert.AreEqual(1, finder.FindMedian());

            finder.AddNum(2);

            Assert.AreEqual(1.5, finder.FindMedian());

            finder.AddNum(3);

            Assert.AreEqual(2, finder.FindMedian());

            finder.AddNum(3);

            Assert.AreEqual(2.5, finder.FindMedian());

            finder.AddNum(3);

            Assert.AreEqual(3, finder.FindMedian());

            finder.AddNum(3);

            Assert.AreEqual(3, finder.FindMedian());
        }
        
        [TestMethod]
        public void Example2()
        {
            var finder = new MedianFinder();

            var values = new[]
            {
                40,12,16,14,35,19,34,35,28,35,26,6,8,2,14,25,25,4,33,18,10,14,
                27,3,35,13,24,27,14,5,0,38,19,25,11,14,31,30,11,31,0
            };

            var medians = new[]
            {
                40.00000, 26.00000, 16.00000, 15.00000, 16.00000, 17.50000, 19.00000, 
                26.50000, 28.00000, 31.00000, 28.00000, 27.00000, 26.00000, 22.50000, 
                19.00000, 22.00000, 25.00000, 22.00000, 25.00000, 22.00000, 19.00000, 
                18.50000, 19.00000, 18.50000, 19.00000, 18.50000, 19.00000, 21.50000, 
                19.00000, 18.50000, 18.00000, 18.50000, 19.00000, 19.00000, 19.00000, 
                18.50000, 19.00000, 19.00000, 19.00000, 19.00000, 19.00000
            };

            Assert.AreEqual(values.Length, medians.Length);

            for (int i = 0; i < values.Length; i++)
            {
                var val = values[i];
                var median = medians[i];

                finder.AddNum(val);

                Assert.AreEqual(median, finder.FindMedian(), $"index {i}");
            }
        }

        [TestMethod]
        public void Example3()
        {
            var finder = new MedianFinder();

            finder.AddNum(5);

            Assert.AreEqual(5, finder.FindMedianInt());

            finder.AddNum(15);

            Assert.AreEqual(10, finder.FindMedianInt());

            finder.AddNum(1);

            Assert.AreEqual(5, finder.FindMedianInt());

            finder.AddNum(3);

            Assert.AreEqual(4, finder.FindMedianInt());

            finder.AddNum(13);

            Assert.AreEqual(5, finder.FindMedianInt());
        }
    }
}
