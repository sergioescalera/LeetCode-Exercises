using LeetCode.Attributes;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class DesignHashSet
    {
        public static void Run()
        {
            
        }
    }

    /// <summary>
    /// Design a HashSet without using any built-in hash table libraries.
    /// </summary>
    public class MyHashSet
    {
        private readonly List<int>[] _array;

        public MyHashSet()
            : this(100)
        {
            
        }

        public MyHashSet(int size)
        {
            _array = new List<int>[size];
        }

        /// <summary>
        /// Insert a value into the HashSet.
        /// </summary>
        /// <param name="key"></param>
        public void Add(int key)
        {
            var list = FindOrCreateList(key);

            if (list.Contains(key))
            {
                return;
            }

            list.Add(key);
        }

        /// <summary>
        /// Remove a value in the HashSet. If the value does not exist in the HashSet, do nothing.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(int key)
        {
            var list = FindOrCreateList(key, create: false);

            if (list == null || list.Contains(key) == false)
            {
                return;
            }

            list.Remove(key);
        }

        /// <summary>
        /// Return whether the value exists in the HashSet or not.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(int key)
        {
            var list = FindOrCreateList(key, create: false);

            if (list == null)
            {
                return false;
            }

            return list.Contains(key);
        }

        private List<int> FindOrCreateList(int key, bool create = true)
        {
            var n = key % _array.Length;

            if (_array[n] == null && create)
            {
                _array[n] = new List<int>();
            }

            return _array[n];
        }
    }
}
