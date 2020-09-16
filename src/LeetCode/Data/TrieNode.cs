using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LeetCode.Data
{
    [DebuggerDisplay("{value}: children {children.Count}")]
    public class TrieNode<T>
    {
        protected readonly SortedDictionary<T, TrieNode<T>> children;

        protected readonly T value;

        protected Boolean IsCompleteWord { get; private set; }

        public TrieNode(T val)
        {
            if (val == null)
            {
                throw new ArgumentNullException(nameof(val));
            }
            
            children = new SortedDictionary<T, TrieNode<T>>();

            value = val;
        }
        
        public virtual void Add(IList<T> word, int index)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (index > word.Count)
            {
                throw new InvalidOperationException();
            }

            if (index == word.Count)
            {
                IsCompleteWord = true;

                return;
            }

            var letter = word[index];

            if (children.ContainsKey(letter) == false)
            {
                children.Add(letter, new TrieNode<T>(letter));
            }

            children[letter].Add(word, index + 1);
        }

        public virtual Boolean Contains(IList<T> word, int index)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (index > word.Count)
            {
                throw new InvalidOperationException();
            }

            if (index == word.Count)
            {
                return IsCompleteWord;
            }

            var letter = word[index];

            if (children.ContainsKey(letter) == false)
            {
                return false;
            }

            return children[letter].Contains(word, index + 1);
        }
    }
}
