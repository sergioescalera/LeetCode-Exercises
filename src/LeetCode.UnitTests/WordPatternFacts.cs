using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("290. Word Pattern")]
    public class WordPatternFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new WordPatternSolution();

            Assert.IsTrue(sol.WordPattern("abba", "dog cat cat dog"));
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new WordPatternSolution();

            Assert.IsFalse(sol.WordPattern("abba", "dog cat cat fish"));
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new WordPatternSolution();

            Assert.IsFalse(sol.WordPattern("aaaa", "dog cat cat dog"));
        }


        [TestMethod]
        public void Example4()
        {
            var sol = new WordPatternSolution();

            Assert.IsFalse(sol.WordPattern("abba", "dog dog dog dog"));
        }
    }
}
