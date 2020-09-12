using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0216. Combination Sum III")]
    public class CombinationSumIIIFacts
    {
        [TestMethod]
        public void Example0()
        {
            var sol = new CombinationSumIII();

            var expected = new[]
            {
                "7, 8, 9"
            };

            var output = sol
                .CombinationSum3(k: 3, n: 24)
                .Select(o => string.Join(", ", o))
                .ToList();

            CollectionAssert.AreEquivalent(expected, output);
        }

        [TestMethod]
        public void Example0_1()
        {
            var sol = new CombinationSumIII();

            var expected = new IList<int>[0];

            var output = sol
                .CombinationSum3(k: 3, n: 25)
                .Select(o => string.Join(", ", o))
                .ToList();

            CollectionAssert.AreEquivalent(expected, output);
        }

        [TestMethod]
        public void Example0_2()
        {
            var sol = new CombinationSumIII();

            var expected = new[]
            {
                "1, 2, 3"
            };

            var output = sol
                .CombinationSum3(k: 3, n: 6)
                .Select(o => string.Join(", ", o))
                .ToList();

            CollectionAssert.AreEquivalent(expected, output);
        }

        [TestMethod]
        public void Example0_3()
        {
            var sol = new CombinationSumIII();

            var expected = new IList<int>[0];

            var output = sol
                .CombinationSum3(k: 3, n: 5)
                .Select(o => string.Join(", ", o))
                .ToList();

            CollectionAssert.AreEquivalent(expected, output);
        }
        [TestMethod]
        public void Example0_4()
        {
            var sol = new CombinationSumIII();

            var expected = new[]
            {
                "1, 2, 3, 4, 5, 6, 7, 8, 9"
            };

            var output = sol
                .CombinationSum3(k: 9, n: 45)
                .Select(o => string.Join(", ", o))
                .ToList();

            CollectionAssert.AreEquivalent(expected, output);
        }
        [TestMethod]
        public void Example1()
        {
            var sol = new CombinationSumIII();

            var expected = new[]
            {
                "1, 2, 4"
            };

            var output = sol
                .CombinationSum3(k: 3, n: 7)
                .Select(o => string.Join(", ", o))
                .ToList();

            CollectionAssert.AreEquivalent(expected, output);
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new CombinationSumIII();

            var expected = new[]
            {
                "1, 2, 6",
                "1, 3, 5",
                "2, 3, 4"
            };

            var output = sol
                .CombinationSum3(k: 3, n: 9)
                .Select(o => string.Join(", ", o))
                .ToList(); ;

            CollectionAssert.AreEquivalent(expected, output);
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new CombinationSumIII();

            var expected = new[]
            {
                "1, 5, 9",
                "1, 6, 8",
                "2, 4, 9",
                "2, 5, 8",
                "2, 6, 7",
                "3, 4, 8",
                "3, 5, 7",
                "4, 5, 6"
            };

            var output = sol
                .CombinationSum3(k: 3, n: 15)
                .Select(o => string.Join(", ", o))
                .ToList(); ;

            CollectionAssert.AreEquivalent(expected, output);
        }
    }
}
