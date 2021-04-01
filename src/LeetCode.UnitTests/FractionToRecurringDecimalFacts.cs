using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0166. Fraction to Recurring Decimal")]
    public class FractionToRecurringDecimalFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new FractionToRecurringDecimal();

            Assert.AreEqual("0.5", sol.FractionToDecimal(1, 2));

            Assert.AreEqual("1.5", sol.FractionToDecimal(3, 2));

            Assert.AreEqual("1.5", sol.FractionToDecimal(-3, -2));

            Assert.AreEqual("-1.5", sol.FractionToDecimal(-3, 2));

            Assert.AreEqual("-0.5", sol.FractionToDecimal(1, -2));
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new FractionToRecurringDecimal();

            Assert.AreEqual("2", sol.FractionToDecimal(2, 1));

            Assert.AreEqual("1", sol.FractionToDecimal(2, 2));

            Assert.AreEqual("-2", sol.FractionToDecimal(-2, 1));

            Assert.AreEqual("-1", sol.FractionToDecimal(2, -2));

            Assert.AreEqual("2", sol.FractionToDecimal(-2, -1));

            Assert.AreEqual("1", sol.FractionToDecimal(-2, -2));
        }

        [TestMethod]
        public void Example3()
        {
            var sol = new FractionToRecurringDecimal();

            Assert.AreEqual("0.(6)", sol.FractionToDecimal(2, 3));
        }

        [TestMethod]
        public void Example4()
        {
            var sol = new FractionToRecurringDecimal();

            Assert.AreEqual("0.(012)", sol.FractionToDecimal(4, 333));
        }

        [TestMethod]
        public void Example5()
        {
            var sol = new FractionToRecurringDecimal();

            Assert.AreEqual("-233.(3231)", sol.FractionToDecimal(777666, -3333));
        }
    }
}
