using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.UnitTests
{
    [TestCategory("189. Rotate Array")]
    [TestClass]
    public class RotateArrayFacts
    {
        [TestMethod]
        public void OneElem()
        {
            var nums = new[] { 1 };
            var expected = new[] { 1 };

            var sol = new RotateArray();

            for (int i = 0; i < 10; i++)
            {
                sol.Rotate(nums, i);

                CollectionAssert.AreEqual(expected, nums);
            }
        }

        [TestMethod]
        public void TwoElem()
        {
            var nums = new[] { 1, 2 };
            
            var sol = new RotateArray();

            sol.Rotate(nums, 0);

            CollectionAssert.AreEqual(new[] { 1, 2 }, nums);

            sol.Rotate(nums, 1);

            CollectionAssert.AreEqual(new[] { 2, 1 }, nums);

            sol.Rotate(nums, 2);

            CollectionAssert.AreEqual(new[] { 2, 1 }, nums);

            sol.Rotate(nums, 3);

            CollectionAssert.AreEqual(new[] { 1, 2 }, nums);

            sol.Rotate(nums, 4);

            CollectionAssert.AreEqual(new[] { 1, 2 }, nums);
        }

        [TestMethod]
        public void ThreeElem()
        {
            var nums = new[] { 1, 2, 3 };

            var sol = new RotateArray();

            sol.Rotate(nums, 0);

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, nums);

            sol.Rotate(nums, 1);

            CollectionAssert.AreEqual(new[] { 3, 1, 2 }, nums);

            sol.Rotate(nums, 2);

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, nums);

            sol.Rotate(nums, 3);

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, nums);

            sol.Rotate(nums, 4);

            CollectionAssert.AreEqual(new[] { 3, 1, 2 }, nums);

            sol.Rotate(nums, 5);

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, nums);
        }

        [TestMethod]
        public void Example1()
        {
            var nums = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var k = 3;
            var expected = new[] { 5, 6, 7, 1, 2, 3, 4 };

            var sol = new RotateArray();

            sol.Rotate(nums, k);

            CollectionAssert.AreEqual(expected, nums);
        }

        [TestMethod]
        public void Example2()
        {
            var nums = new[] { -1, -100, 3, 99 };
            var k = 2;
            var expected = new[] { 3, 99, -1, -100 };

            var sol = new RotateArray();

            sol.Rotate(nums, k);

            CollectionAssert.AreEqual(expected, nums);
        }

        [TestMethod]
        public void Example3()
        {
            var nums = new[] { 1, 2, 3, 4, 5, 6 };
            var k = 2;
            var expected = new[] { 5, 6, 1, 2, 3, 4 };

            var sol = new RotateArray();

            sol.Rotate(nums, k);

            CollectionAssert.AreEqual(expected, nums);
        }

        [TestMethod]
        public void Example4()
        {
            var nums = new[] { 1, 2, 3, 4, 5, 6 };
            var k = 3;
            var expected = new[] { 4, 5, 6, 1, 2, 3 };

            var sol = new RotateArray();

            sol.Rotate(nums, k);

            CollectionAssert.AreEqual(expected, nums);
        }

        [TestMethod]
        public void Example50Elems()
        {
            var nums = Enumerable
                .Repeat(0, 50)
                .Select((z, i) => i)
                .ToArray();

            var sol = new RotateArray();

            for (int i = 0; i < nums.Length * 2; i++)
            {
                var array = nums.Clone() as int[];

                var expected = new List<int>(nums.Clone() as int[]);

                var k = i % nums.Length;

                sol.Rotate(array, i);

                for (int j = 0; j < k; j++)
                {
                    var n = expected[expected.Count - 1];

                    expected.RemoveAt(expected.Count - 1);

                    expected.Insert(0, n);
                }

                CollectionAssert.AreEqual(expected, array, $"i = {i}");
            }
        }

        [TestMethod]
        public void Example101Elems()
        {
            var nums = Enumerable
                .Repeat(0, 101)
                .Select((z, i) => i)
                .ToArray();

            var sol = new RotateArray();

            for (int i = 0; i < nums.Length * 2; i++)
            {
                var array = nums.Clone() as int[];

                var expected = new List<int>(nums.Clone() as int[]);

                var k = i % nums.Length;

                sol.Rotate(array, i);

                for (int j = 0; j < k ; j++)
                {
                    var n = expected[expected.Count - 1];

                    expected.RemoveAt(expected.Count - 1);

                    expected.Insert(0, n);
                }

                CollectionAssert.AreEqual(expected, array, $"i = {i}");
            }
        }

        [TestMethod]
        public void Example1010Elems()
        {
            var nums = Enumerable
                .Repeat(0, 1010)
                .Select((z, i) => i)
                .ToArray();

            var sol = new RotateArray();

            for (int i = 0; i < nums.Length * 2; i++)
            {
                var array = nums.Clone() as int[];

                var expected = new List<int>(nums.Clone() as int[]);

                var k = i % nums.Length;

                sol.Rotate(array, i);

                for (int j = 0; j < k; j++)
                {
                    var n = expected[expected.Count - 1];

                    expected.RemoveAt(expected.Count - 1);

                    expected.Insert(0, n);
                }

                CollectionAssert.AreEqual(expected, array, $"i = {i}");
            }
        }
    }
}
