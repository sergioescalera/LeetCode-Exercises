using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("459. Repeated Substring Pattern")]
    public class RepeatedSubstringPatternFacts
    {
        [TestMethod]
        public void ShouldReturnFalseWhenNullOrEmpty()
        {
            var sol = new RepeatedSubstringPatternSolution();

            Assert.IsFalse(sol.RepeatedSubstringPattern(null));
            Assert.IsFalse(sol.RepeatedSubstringPattern(String.Empty));
        }

        [TestMethod]
        public void ShouldReturnFalseWhenOneLetter()
        {
            var sol = new RepeatedSubstringPatternSolution();

            Assert.IsFalse(sol.RepeatedSubstringPattern("a"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("z"));
        }

        [TestMethod]
        public void TwoLetters()
        {
            var sol = new RepeatedSubstringPatternSolution();

            Assert.IsTrue(sol.RepeatedSubstringPattern("aa"));
            Assert.IsTrue(sol.RepeatedSubstringPattern("zz"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("ab"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("xy"));
        }

        [TestMethod]
        public void ThreeLetters()
        {
            var sol = new RepeatedSubstringPatternSolution();

            Assert.IsTrue(sol.RepeatedSubstringPattern("aaa"));
            Assert.IsTrue(sol.RepeatedSubstringPattern("bbb"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("zaz"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("abc"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("xxy"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("xyy"));
        }

        [TestMethod]
        public void FourLetters()
        {
            var sol = new RepeatedSubstringPatternSolution();

            Assert.IsTrue(sol.RepeatedSubstringPattern("aaaa"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("bbaa"));
            Assert.IsTrue(sol.RepeatedSubstringPattern("zaza"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("aaab"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("abcd"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("xxyz"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("xyyz"));
        }

        [TestMethod]
        public void FiveLetters()
        {
            var sol = new RepeatedSubstringPatternSolution();

            Assert.IsTrue(sol.RepeatedSubstringPattern("aaaaa"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("bbaaa"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("zazza"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("aaaab"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("abcde"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("xxyzz"));
            Assert.IsFalse(sol.RepeatedSubstringPattern("xyyzz"));
        }
    }
}
