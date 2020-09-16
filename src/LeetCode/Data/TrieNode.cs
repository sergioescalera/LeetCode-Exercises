using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LeetCode.Data
{
    [DebuggerDisplay("{Value}: children {children.Count}")]
    public class TrieNode<T>
    {
        public SortedDictionary<T, TrieNode<T>> Children
        {
            get;
        }

        public Boolean IsCompleteWord
        {
            get; private set;
        }

        public T Value
        {
            get;
        }

        public TrieNode(T val)
        {
            if (val == null)
            {
                throw new ArgumentNullException(nameof(val));
            }
            
            Children = new SortedDictionary<T, TrieNode<T>>();

            Value = val;
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

            if (Children.ContainsKey(letter) == false)
            {
                Children.Add(letter, new TrieNode<T>(letter));
            }

            Children[letter].Add(word, index + 1);
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

            if (Children.ContainsKey(letter) == false)
            {
                return false;
            }

            return Children[letter].Contains(word, index + 1);
        }
    }
}
