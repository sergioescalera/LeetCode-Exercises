using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0345 - Reverse Vowels of a String")]
    public class ReverseStringFacts
    {
        [TestMethod]
        public void Example1()
        {
            var str = "hello";

            var sol = new ReverseString();

            Assert.AreEqual("holle", sol.Reverse(str));
        }

        [TestMethod]
        public void Example2()
        {
            var str = "leetcode";

            var sol = new ReverseString();

            Assert.AreEqual("leotcede", sol.Reverse(str));
        }

        [TestMethod]
        public void Examples()
        {
            var reverser = new ReverseString(c => char.IsLetter(c));

            Assert.IsNull(reverser.Reverse(null));
            Assert.AreEqual("", reverser.Reverse(""));
            Assert.AreEqual("a", reverser.Reverse("a"));
            Assert.AreEqual("$", reverser.Reverse("$"));
            Assert.AreEqual("ba", reverser.Reverse("ab"));
            Assert.AreEqual("a$", reverser.Reverse("a$"));
            Assert.AreEqual("b$a", reverser.Reverse("a$b"));
            Assert.AreEqual("c$ba", reverser.Reverse("a$bc"));
            Assert.AreEqual("cb$a", reverser.Reverse("ab$c"));
            Assert.AreEqual("cb$a?", reverser.Reverse("ab$c?"));
            Assert.AreEqual(".c\b$a?", reverser.Reverse(".a\b$c?"));
        }
    }
}
