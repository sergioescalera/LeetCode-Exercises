using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0134. Gas Station")]
    public class GasStationFacts
    {
        [TestMethod]
        public void Empty()
        {
            Assert.AreEqual(-1, new GasStation().CanCompleteCircuit(
                new int[] { },
                new int[] { }));
        }

        [TestMethod]
        public void OneStation()
        {
            Assert.AreEqual(-1, new GasStation().CanCompleteCircuit(
                new int[] { 10 },
                new int[] { 22 }));

            Assert.AreEqual(0, new GasStation().CanCompleteCircuit(
                new int[] { 3 },
                new int[] { 3 }));

            Assert.AreEqual(0, new GasStation().CanCompleteCircuit(
                new int[] { 3 },
                new int[] { 2 }));
        }

        [TestMethod]
        public void Example1()
        {
            Assert.AreEqual(3, new GasStation().CanCompleteCircuit(
                new[] { 1, 2, 3, 4, 5 },
                new[] { 3, 4, 5, 1, 2 }));
        }

        [TestMethod]
        public void Example2()
        {
            Assert.AreEqual(-1, new GasStation().CanCompleteCircuit(
                new[] { 2, 3, 4 },
                new[] { 3, 4, 3 }));
        }
    }
}
