using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0229. Majority Element II")]
    public class MajorityElementFacts
    {
        [TestMethod]
        public void EmptyOrNull()
        {
            CollectionAssert.AreEqual(
                new int[0],
                new MajorityElementII().MajorityElement(null).ToArray());

            CollectionAssert.AreEqual(
                new int[0],
                new MajorityElementII().MajorityElement(new int[0]).ToArray());
        }

        [TestMethod]
        public void OneELem()
        {
            CollectionAssert.AreEqual(
                new int[] { 5 },
                new MajorityElementII().MajorityElement(new[] { 5 }).ToArray());

            CollectionAssert.AreEqual(
                new int[] { int.MaxValue },
                new MajorityElementII().MajorityElement(new int[] { int.MaxValue }).ToArray());
        }

        [TestMethod]
        public void SameElem()
        {
            CollectionAssert.AreEqual(
                new int[] { 5 },
                new MajorityElementII().MajorityElement(new[] { 5, 5 }).ToArray());

            CollectionAssert.AreEqual(
                new int[] { 5 },
                new MajorityElementII().MajorityElement(new[] { 5, 5, 5, 5, 5 }).ToArray());

            CollectionAssert.AreEqual(
                new int[] { 0 },
                new MajorityElementII().MajorityElement(new int[] { 0, 0 }).ToArray());
        }

        [TestMethod]
        public void TwoElem()
        {
            CollectionAssert.AreEquivalent(
                new int[] { 0, 1 },
                new MajorityElementII().MajorityElement(new[] { 0, 1 }).ToArray());
        }

        [TestMethod]
        public void Exmaple1()
        {
            CollectionAssert.AreEqual(
                new int[] { 3 },
                new MajorityElementII().MajorityElement(new[] { 3, 2, 3 }).ToArray());
        }

        [TestMethod]
        public void Example2()
        {
            CollectionAssert.AreEquivalent(
                new int[] { 1, 2 },
                new MajorityElementII().MajorityElement(new[] { 1, 1, 1, 3, 3, 2, 2, 2 }).ToArray());
        }

        [TestMethod]
        public void Example3()
        {
            CollectionAssert.AreEquivalent(
                new int[] { 0 },
                new MajorityElementII().MajorityElement(new[] { 0, 3, 4, 0 }).ToArray());
        }

        [TestMethod]
        public void Example4()
        {
            CollectionAssert.AreEquivalent(
                new int[] { 1 },
                new MajorityElementII().MajorityElement(new[] { 1, 1, 1, 2, 3, 4, 5, 6 }).ToArray());
        }
    }
}
