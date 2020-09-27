using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0399. EvaluateDivision")]
    public class EvaluateDivisionFacts
    {
        [TestMethod]
        public void Exampe1()
        {
            var sol = new EvaluateDivision();

            var result = sol.CalcEquation(
                new[] { new[] { "a", "b" }, new[] { "b", "c" } },
                new[] { 2.0, 3.0 },
                new[] {
                    new[] { "a", "c" },
                    new[] { "b", "a" },
                    new[] { "a", "e" },
                    new[] { "a", "a" },
                    new[] { "x", "x" } });

            CollectionAssert.AreEqual(
                new[] { 6.0, 0.5, -1.0, 1.0, -1.0 },
                result);
        }

        [TestMethod]
        public void Exampe2()
        {
            var sol = new EvaluateDivision();

            var result = sol.CalcEquation(
                new[] { new[] { "a", "b" }, new[] { "b", "c" }, new[] { "bc", "cd" } },
                new[] { 1.5, 2.5, 5.0 },
                new[] { 
                    new[] { "a", "c" }, 
                    new[] { "c", "b" }, 
                    new[] { "bc", "cd" }, 
                    new[] { "cd", "bc" } });

            CollectionAssert.AreEqual(
                new[] { 3.75000, 0.40000, 5.00000, 0.20000 },
                result);
        }

        [TestMethod]
        public void Exampe3()
        {
            var sol = new EvaluateDivision();

            var result = sol.CalcEquation(
                new[] { new[] { "a", "b" } },
                new[] { 0.5 },
                new[] {
                    new[] { "a", "b" },
                    new[] { "b", "a" },
                    new[] { "a", "c" },
                    new[] { "x", "y" } });

            CollectionAssert.AreEqual(
                new[] { 0.50000, 2.00000, -1.00000, -1.00000 },
                result);
        }

        [TestMethod]
        public void Example4()
        {
            var sol = new EvaluateDivision();

            var result = sol.CalcEquation(
                new[] { 
                    new[] { "x1", "x2" }, 
                    new[] { "x2", "x3" }, 
                    new[] { "x3", "x4" }, 
                    new[] { "x4", "x5" } },
                new[] { 3.0, 4.0, 5.0, 6.0 },
                new[] {
                    new[] { "x1", "x5" },
                    new[] { "x5", "x2" },
                    new[] { "x2", "x4" },
                    new[] { "x2", "x2" },
                    new[] { "x2", "x9" },
                    new[] { "x9", "x9" }});

            CollectionAssert.AreEqual(
                new[] { 360.00000, 0.00833, 20.00000, 1.00000, -1.00000, -1.00000 },
                result.Select(x => Math.Round(x, 5)).ToArray());
        }
    }
}
