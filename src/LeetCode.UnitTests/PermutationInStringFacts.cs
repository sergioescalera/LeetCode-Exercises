using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0567. Permutation in String")]
    public class PermutationInStringFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new PermutationInString();

            Assert.IsTrue(sol.CheckInclusion("ab", "eidbaooo"));
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new PermutationInString();

            Assert.IsFalse(sol.CheckInclusion("ab", "eidboaoo"));
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new PermutationInString();

            Assert.IsTrue(sol.CheckInclusion("adc", "dcda"));

            Assert.IsFalse(sol.CheckInclusion("adc", "dcdx"));
        }

        [TestMethod]
        public void Example4()
        {
            var sol = new PermutationInString();

            Assert.IsTrue(sol.CheckInclusion("a", "a"));

            Assert.IsFalse(sol.CheckInclusion("a", "b"));
        }
    }
}
