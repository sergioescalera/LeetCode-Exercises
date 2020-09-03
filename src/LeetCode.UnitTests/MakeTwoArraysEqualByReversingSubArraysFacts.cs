using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("1460. Make Two Arrays Equal by Reversing Sub-arrays")]
    public class MakeTwoArraysEqualByReversingSubArraysFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new MakeTwoArraysEqualByReversingSubArrays();

            var result = sol.CanBeEqual
                (
                    new[] { 1, 2, 3, 4 },
                    new[] { 2, 4, 1, 3 }
                );

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new MakeTwoArraysEqualByReversingSubArrays();

            Assert.IsTrue(sol.CanBeEqual
                (
                    new[] { 7 },
                    new[] { 7 }
                ));

            Assert.IsFalse(sol.CanBeEqual
                (
                    new[] { 7 },
                    new[] { 8 }
                ));
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new MakeTwoArraysEqualByReversingSubArrays();

            Assert.IsTrue(sol.CanBeEqual
                (
                    new[] { 1, 12 },
                    new[] { 12, 1 }
                ));

            Assert.IsFalse(sol.CanBeEqual
                (
                    new[] { 7, 9 },
                    new[] { 8, 7 }
                ));
        }

        [TestMethod]
        public void Example4()
        {
            var sol = new MakeTwoArraysEqualByReversingSubArrays();

            Assert.IsFalse(sol.CanBeEqual
                (
                    new[] { 3, 7, 9 },
                    new[] { 3, 7, 11 }
                ));

            Assert.IsTrue(sol.CanBeEqual
                (
                    new[] { 3, 7, 11 },
                    new[] { 3, 7, 11 }
                ));
        }

        [TestMethod]
        public void Example5()
        {
            var sol = new MakeTwoArraysEqualByReversingSubArrays();

            Assert.IsTrue(sol.CanBeEqual
                (
                    new[] { 1, 1, 1, 1, 1 },
                    new[] { 1, 1, 1, 1, 1 }
                ));

            Assert.IsFalse(sol.CanBeEqual
                (
                    new[] { 1, 1, 1, 1, 1 },
                    new[] { 1, 1, 1, 1, 2 }
                ));
        }
    }
}
