using LeetCode.Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("Quick Sort")]
    public class QuickSortFacts
    {
        [TestMethod]
        public void SameElement()
        {
            var array = new[] { 4, 4, 4 };
            var expected = new[] { 4, 4, 4 };

            QuickSort.Sort(array);

            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void SortedArray()
        {
            var array = new[] { 1, 2, 3 };
            var expected = new[] { 1, 2, 3 };

            QuickSort.Sort(array);

            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void ReversedArray()
        {
            var array = new[] { 3, 2, 1 };
            var expected = new[] { 1, 2, 3 };

            QuickSort.Sort(array);

            CollectionAssert.AreEqual(expected, array);
        }
    }
}
