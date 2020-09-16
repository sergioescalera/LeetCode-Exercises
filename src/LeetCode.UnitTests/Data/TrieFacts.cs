using LeetCode.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("Data - Trie")]
    public class TrieFacts
    {
        [TestMethod]
        public void CanCreateInstance()
        {
            var trie = new Trie<char>();

            Assert.IsNotNull(trie);
        }

        [TestMethod]
        public void CanAdd()
        {
            var trie = new Trie<char>();

            var word = "a".ToCharArray();

            Assert.IsFalse(trie.Contains(word));

            trie.Add(word);

            Assert.IsTrue(trie.Contains(word));
        }

        [TestMethod]
        public void CanAdd2()
        {
            var trie = new Trie<char>();

            var a = "a".ToCharArray();
            var ab = "ab".ToCharArray();
            var abc = "abc".ToCharArray();

            trie.Add(a);
            trie.Add(ab);
            
            Assert.IsTrue(trie.Contains(a));
            Assert.IsTrue(trie.Contains(ab));
            Assert.IsFalse(trie.Contains(abc));
        }

        [TestMethod]
        public void CanAdd3()
        {
            var trie = new Trie<char>();

            var a = "a".ToCharArray();
            var ab = "ab".ToCharArray();
            var abc = "abc".ToCharArray();
            var abcd = "abcd".ToCharArray();

            trie.Add(a);
            trie.Add(ab);
            trie.Add(abcd);

            Assert.IsTrue(trie.Contains(a));
            Assert.IsTrue(trie.Contains(ab));
            Assert.IsFalse(trie.Contains(abc));
            Assert.IsTrue(trie.Contains(abcd));
        }
    }
}
