using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("220. Contains Duplicate III")]
    public class ContainsDuplicate3Facts
    {
        [TestMethod]
        public void ShouldReturnFalseWhenNullNums()
        {
            var sol = new ContainsDuplicateIII();

            Assert.IsFalse(sol.ContainsNearbyAlmostDuplicate(null, 1, 1));
        }

        [TestMethod]
        public void ShouldReturnFalseWhenEmptyNums()
        {
            var sol = new ContainsDuplicateIII();

            Assert.IsFalse(sol.ContainsNearbyAlmostDuplicate(new int[0], 1, 1));
        }

        [TestMethod]
        public void ShouldReturnFalseWhenKIsLessOrEqualThan0()
        {
            var sol = new ContainsDuplicateIII();

            Assert.IsFalse(sol.ContainsNearbyAlmostDuplicate(new int[] { 1, 1 }, 0, 0));

            Assert.IsFalse(sol.ContainsNearbyAlmostDuplicate(new int[] { 1, 2 }, 0, 1));
        }

        [TestMethod]
        public void ShouldReturnFalseWhenTIsLessThan0()
        {
            var sol = new ContainsDuplicateIII();

            Assert.IsFalse(sol.ContainsNearbyAlmostDuplicate(new int[] { 1, 2 }, 1, -1));

            Assert.IsFalse(sol.ContainsNearbyAlmostDuplicate(new int[] { 1, 1 }, 1, -1));
        }

        [TestMethod]
        public void Example1ShouldReturnTrue()
        {
            var sol = new ContainsDuplicateIII();

            Assert.IsTrue(sol.ContainsNearbyAlmostDuplicate(new int[] { 1, 2, 3, 1 }, 3, 0));
        }

        [TestMethod]
        public void Example2ShouldReturnTrue()
        {
            var sol = new ContainsDuplicateIII();

            Assert.IsTrue(sol.ContainsNearbyAlmostDuplicate(new int[] { 1, 0, 1, 1 }, 1, 2));
        }

        [TestMethod]
        public void Example3ShouldReturnFalse()
        {
            var sol = new ContainsDuplicateIII();

            Assert.IsFalse(sol.ContainsNearbyAlmostDuplicate(new int[] { 1, 5, 9, 1, 5, 9 }, 2, 3));
        }

        [TestMethod]
        public void Example4ShouldReturnTrue()
        {
            var sol = new ContainsDuplicateIII();

            Assert.IsTrue(sol.ContainsNearbyAlmostDuplicate(new int[] { 3, 6, 0, 4 }, 2, 2));
        }

        [TestMethod]
        public void Example5ShouldNotOverflow()
        {
            var sol = new ContainsDuplicateIII();

            Assert.IsFalse(sol.ContainsNearbyAlmostDuplicate(new int[] { -1, 2147483647 }, 1, 2147483647));
        }
    }
}
