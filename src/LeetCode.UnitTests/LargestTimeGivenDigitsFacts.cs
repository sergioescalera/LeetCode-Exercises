using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("949. Largest Time for Given Digits")]
    public class LargestTimeGivenDigitsFacts
    {
        [TestMethod]
        public void TestCase1234()
        {
            var solution = new LargestTimeGivenDigits();

            var output = solution.LargestTimeFromDigits(new[] { 1, 2, 3, 4 });

            Assert.AreEqual("23:41", output);
        }

        [TestMethod]
        public void TestCase5555()
        {
            var solution = new LargestTimeGivenDigits();

            var output = solution.LargestTimeFromDigits(new[] { 5, 5, 5, 5 });

            Assert.AreEqual("", output);
        }

        [TestMethod]
        public void TestCase0024()
        {
            var solution = new LargestTimeGivenDigits();

            var output = solution.LargestTimeFromDigits(new[] { 0, 0, 2, 4 });

            Assert.AreEqual("20:40", output);
        }

        [TestMethod]
        public void TestCase0000()
        {
            var solution = new LargestTimeGivenDigits();

            var output = solution.LargestTimeFromDigits(new[] { 0, 0, 0, 0 });

            Assert.AreEqual("00:00", output);
        }

        [TestMethod]
        public void TestCase2359()
        {
            var solution = new LargestTimeGivenDigits();

            var output = solution.LargestTimeFromDigits(new[] { 2, 9, 5, 3 });

            Assert.AreEqual("23:59", output);
        }

        [TestMethod]
        public void TestCase1960()
        {
            var solution = new LargestTimeGivenDigits();

            var output = solution.LargestTimeFromDigits(new[] { 1, 9, 6, 0 });

            Assert.AreEqual("19:06", output);
        }
    }
}
