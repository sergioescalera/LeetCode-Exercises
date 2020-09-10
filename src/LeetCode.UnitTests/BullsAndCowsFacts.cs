using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestCategory("299. Bulls and Cows")]
    [TestClass]
    public class BullsAndCowsFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new BullsAndCows();

            Assert.AreEqual("1A3B", sol.GetHint("1807", "7810"));
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new BullsAndCows();

            Assert.AreEqual("1A1B", sol.GetHint("1123", "0111"));
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new BullsAndCows();

            Assert.AreEqual("1A0B", sol.GetHint("1234", "1111"));

            Assert.AreEqual("1A0B", sol.GetHint("4321", "2222"));
        }
    }
}
