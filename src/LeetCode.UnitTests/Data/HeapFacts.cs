using LeetCode.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.UnitTests
{
    public class HeapFacts
    {
        [TestCategory("Data - Heap")]
        [TestClass]
        public class Constructor
        {
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            [TestMethod]
            public void ShouldThrowWhenNegativeCapacity()
            {
                new Heap<int>(-10);
            }

            [TestMethod]
            public void ShouldCreateInstanceWithoutParams()
            {
                var heap = new Heap<int>();

                Assert.IsNotNull(heap);
                Assert.AreEqual(0, heap.Size);
            }

            [TestMethod]
            public void ShouldCreateInstanceWithCapacity()
            {
                var heap = new Heap<int>(100);

                Assert.IsNotNull(heap);
                Assert.AreEqual(0, heap.Size);
                Assert.AreEqual(100, heap.Capacity);
            }
        }

        [TestCategory("Data - Heap")]
        [TestClass]
        public class AddMethod
        {
            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ShoulThrowWhenNull()
            {
                var heap = new Heap<string>();

                heap.Add(null);
            }

            [TestMethod]
            public void ShouldAddElements()
            {
                var heap = new Heap<int>();

                var rnd = new Random();
                var set = new SortedSet<int>();

                while (heap.Size < 100000)
                {
                    var n = rnd.Next();

                    if (set.Contains(n) == false)
                    {
                        set.Add(n);
                    }

                    heap.Add(n);

                    Assert.AreEqual(set.Min, heap.Peek());
                }
            }
        }

        [TestCategory("Data - Heap")]
        [TestClass]
        public class PollMethod
        {
            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ShoulThrowWhenNull()
            {
                var heap = new Heap<string>();

                heap.Poll();
            }

            [TestMethod]
            public void ShouldRemoveElements()
            {
                var heap = new Heap<int>();

                var rnd = new Random();
                var set = new SortedSet<int>();

                for (int i = 0; i < 1000000; i++)
                {
                    var remove = rnd.Next() % 3 == 0;

                    if (remove)
                    {
                        if (heap.Size == 0)
                        {
                            continue;
                        }

                        var min = heap.Poll();

                        Assert.IsTrue(set.Remove(min));

                        Assert.AreEqual(set.Count, heap.Size);

                        if (set.Count > 0)
                        {
                            Assert.AreEqual(set.Min, heap.Peek());
                        }
                    }
                    else
                    {
                        var n = rnd.Next();

                        if (set.Contains(n))
                        {
                            continue;
                        }

                        set.Add(n);
                        heap.Add(n);

                        Assert.AreEqual(set.Count, heap.Size);
                        Assert.AreEqual(set.Min, heap.Peek());
                    }
                }
            }
        }
    }
}
