using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("1116. Print Zero Even Odd")]
    public class ZeroEvenOddFacts
    {
        const int timeout = 1000 * 10;

        [TestMethod]
        public async Task N1()
        {
            var o = new ZeroEvenOdd(1);
            var s = "";

            var tasks = new[]
            {
                Task.Factory.StartNew(() =>
                {
                    o.Even((i) => s += i);
                }),
                Task.Factory.StartNew(() =>
                {
                    o.Zero((i) => s += i);
                }),
                Task.Factory.StartNew(() =>
                {
                    o.Odd((i) => s += i);
                })
            };

            var delay = Task.Delay(timeout);
            var result = await Task.WhenAny(Task.WhenAll(tasks), delay);

            if (delay == result)
            {
                Assert.Fail("Timeout");
            }

            Assert.AreEqual("01", s);
        }

        [TestMethod]
        public async Task N2()
        {
            var o = new ZeroEvenOdd(2);
            var s = "";

            var tasks = new[]
            {
                Task.Factory.StartNew(() =>
                {
                    o.Even((i) => s += i);
                }),
                Task.Factory.StartNew(() =>
                {
                    o.Zero((i) => s += i);
                }),
                Task.Factory.StartNew(() =>
                {
                    o.Odd((i) => s += i);
                })
            };

            var delay = Task.Delay(timeout);
            var result = await Task.WhenAny(Task.WhenAll(tasks), delay);

            if (delay == result)
            {
                Assert.Fail("Timeout");
            }

            Assert.AreEqual("0102", s);
        }

        [TestMethod]
        public async Task N5()
        {
            var o = new ZeroEvenOdd(5);
            var s = "";

            var tasks = new[]
            {
                Task.Factory.StartNew(() =>
                {
                    o.Even((i) => 
                    {
                        s += i;
                    });
                }),
                Task.Factory.StartNew(() =>
                {
                    o.Zero((i) =>
                    {
                        s += i;
                    });
                }),
                Task.Factory.StartNew(() =>
                {
                    o.Odd((i) =>
                    {
                        s += i;
                    });
                })
            };

            var delay = Task.Delay(timeout);
            var result = await Task.WhenAny(Task.WhenAll(tasks), delay);

            if (delay == result)
            {
                Assert.Fail("Timeout");
            }

            Assert.AreEqual("0102030405", s);
        }

        [TestMethod]
        public async Task N555()
        {
            var c = 555;
            var o = new ZeroEvenOdd(c);
            var s = "";

            var tasks = new[]
            {
                Task.Factory.StartNew(() =>
                {
                    o.Even((i) =>
                    {
                        s += i;
                    });
                }),
                Task.Factory.StartNew(() =>
                {
                    o.Zero((i) =>
                    {
                        s += i;
                    });
                }),
                Task.Factory.StartNew(() =>
                {
                    o.Odd((i) =>
                    {
                        s += i;
                    });
                })
            };

            var delay = Task.Delay(timeout);
            var result = await Task.WhenAny(Task.WhenAll(tasks), delay);
            var e = string.Join("", Enumerable.Range(1, c).Select(i => $"0{i}"));

            if (delay == result)
            {
                Assert.Fail("Timeout");
            }

            Assert.AreEqual(e, s);
        }
    }
}
