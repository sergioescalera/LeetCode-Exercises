using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode.Data
{
    public class Trie<T> : IEnumerable<TrieNode<T>>
    {
        protected readonly SortedDictionary<T, TrieNode<T>> children;

        public Trie()
        {
            children = new SortedDictionary<T, TrieNode<T>>();
        }

        public virtual void Add(IList<T> word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (word.Count == 0)
            {
                throw new ArgumentException("Word can't be empty", nameof(word));
            }

            var letter = word[0];

            if (children.ContainsKey(letter) == false)
            {
                children.Add(letter, new TrieNode<T>(letter));
            }

            children[letter].Add(word, 1);
        }

        public virtual Boolean Contains(IList<T> word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (word.Count == 0)
            {
                return false;
            }

            var letter = word[0];

            if (children.ContainsKey(letter) == false)
            {
                return false;
            }

            return children[letter].Contains(word, 1);
        }

        public IEnumerator<TrieNode<T>> GetEnumerator()
        {
            return children.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
