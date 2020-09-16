using System;
using System.Collections.Generic;

namespace LeetCode.Data
{
    public class Trie<T>
    {
        public SortedDictionary<T, TrieNode<T>> Nodes
        {
            get;
        }

        public Trie()
        {
            Nodes = new SortedDictionary<T, TrieNode<T>>();
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

            if (Nodes.ContainsKey(letter) == false)
            {
                Nodes.Add(letter, new TrieNode<T>(letter));
            }

            Nodes[letter].Add(word, 1);
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

            if (Nodes.ContainsKey(letter) == false)
            {
                return false;
            }

            return Nodes[letter].Contains(word, 1);
        }
    }
}
