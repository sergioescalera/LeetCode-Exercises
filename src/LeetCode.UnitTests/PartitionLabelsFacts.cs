using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("763. Partition Labels")]
    public class PartitionLabelsFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new PartitionLabelsSolution();

            CollectionAssert.AreEquivalent(new int[0], sol.PartitionLabels(null).ToList());
            CollectionAssert.AreEquivalent(new int[0], sol.PartitionLabels("").ToList());

            CollectionAssert.AreEquivalent(
                new int[] { 1 },
                sol.PartitionLabels("a").ToList());

            CollectionAssert.AreEquivalent(
                new int[] { 1, 1 },
                sol.PartitionLabels("ab").ToList());

            CollectionAssert.AreEquivalent(
                new int[] { 1, 1, 1 },
                sol.PartitionLabels("abc").ToList());

            CollectionAssert.AreEquivalent(
                new int[] { 4 },
                sol.PartitionLabels("abca").ToList());
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new PartitionLabelsSolution();

            CollectionAssert.AreEquivalent(
                new int[] { 6 },
                sol.PartitionLabels("abcabc").ToList());

            CollectionAssert.AreEquivalent(
                new int[] { 9, 7, 8 },
                sol.PartitionLabels("ababcbacadefegdehijhklij").ToList());
        }
    }
}
