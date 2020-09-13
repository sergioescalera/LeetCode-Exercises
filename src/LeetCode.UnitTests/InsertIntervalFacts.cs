using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0057. Insert Interval")]
    public class InsertIntervalFacts
    {
        [TestMethod]
        public void InsertBetween1()
        {
            var sol = new InsertInterval();

            var output = sol.Insert(new[]
            {
                new[] { 2, 3 },
                new[] { 6, 9 }
            },
            new[] { 0, 1 });

            var expected = new[]
            {
                new [] { 0, 1 },
                new [] { 2, 3 },
                new [] { 6, 9 }
            };

            Assert.AreEqual(expected.Length, output.Length);

            for (int i = 0; i < output.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], output[i]);
            }
        }

        [TestMethod]
        public void InsertBetween2()
        {
            var sol = new InsertInterval();

            var output = sol.Insert(new[]
            {
                new[] { 2, 3 },
                new[] { 6, 9 }
            },
            new[] { 4, 5 });

            var expected = new[]
            {
                new [] { 2, 3 },
                new [] { 4, 5 },
                new [] { 6, 9 }
            };

            Assert.AreEqual(expected.Length, output.Length);

            for (int i = 0; i < output.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], output[i]);
            }
        }

        [TestMethod]
        public void InsertBetween3()
        {
            var sol = new InsertInterval();

            var output = sol.Insert(new[]
            {
                new[] { 2, 3 },
                new[] { 6, 9 }
            },
            new[] { 10, 11 });

            var expected = new[]
            {
                new [] { 2, 3 },
                new [] { 6, 9 },
                new [] { 10, 11 },
            };

            Assert.AreEqual(expected.Length, output.Length);

            for (int i = 0; i < output.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], output[i]);
            }
        }

        [TestMethod]
        public void Example1()
        {
            var sol = new InsertInterval();

            var output = sol.Insert(new[]
            {
                new[] { 1, 3 },
                new[] { 6, 9 }
            },
            new[] { 2, 5 });

            var expected = new[]
            {
                new [] { 1, 5 },
                new [] { 6, 9 }
            };

            Assert.AreEqual(expected.Length, output.Length);

            for (int i = 0; i < output.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], output[i]);
            }
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new InsertInterval();

            var output = sol.Insert(new[]
            {
                new[] { 1, 2 },
                new[] { 3, 5 },
                new[] { 6, 7 },
                new[] { 8, 10 },
                new[] { 12, 16 }
            },
            new[] { 4, 8 });

            var expected = new[]
            {
                new [] { 1, 2 },
                new [] { 3, 10 },
                new [] { 12, 16 }
            };

            Assert.AreEqual(expected.Length, output.Length);

            for (int i = 0; i < output.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], output[i]);
            }
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new InsertInterval();

            var output = sol.Insert(new[]
            {
                new[] { 1, 2 },
                new[] { 3, 5 },
                new[] { 6, 7 },
                new[] { 8, 10 },
                new[] { 12, 16 }
            },
            new[] { 0, 11 });

            var expected = new[]
            {
                new [] { 0, 11 },
                new [] { 12, 16 }
            };

            Assert.AreEqual(expected.Length, output.Length);

            for (int i = 0; i < output.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], output[i]);
            }
        }
    }
}
