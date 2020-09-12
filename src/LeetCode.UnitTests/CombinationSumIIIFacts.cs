using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0216. Combination Sum III")]
    public class CombinationSumIIIFacts
    {
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
    }
}
