using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0165. Compare Version Numbers")]
    public class CompareVersionNumbersFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new CompareVersionNumbers();

            Assert.AreEqual(-1, sol.CompareVersion("0.1", "1.1"));
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new CompareVersionNumbers();

            Assert.AreEqual(1, sol.CompareVersion("1.0.1", "1"));
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new CompareVersionNumbers();

            Assert.AreEqual(-1, sol.CompareVersion("7.5.2.4", "7.5.3"));
        }

        [TestMethod]
        public void Example4()
        {
            var sol = new CompareVersionNumbers();

            Assert.AreEqual(0, sol.CompareVersion("1.01", "1.001"));
        }

        [TestMethod]
        public void Example5()
        {
            var sol = new CompareVersionNumbers();

            Assert.AreEqual(0, sol.CompareVersion("1.0", "1.0.0"));
        }

        [TestMethod]
        public void Example6()
        {
            var sol = new CompareVersionNumbers();

            Assert.AreEqual(-1, sol.CompareVersion("2.9.9.9", "10.0.0"));
        }
    }
}
