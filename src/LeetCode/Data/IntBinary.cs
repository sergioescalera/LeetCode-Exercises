using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Data
{
    public class IntBinary : IList<bool>
    {
        private int Number { get; }

        public IntBinary(int n, int count)
        {
            Number = n;
            Count = count;
        }

        public bool this[int index]
        {
            get
            {
                if (index < Count)
                {
                    var k = Count - index - 1;

                    return ((1 << k) & Number) != 0;
                }

                throw new InvalidOperationException();
            }
            set => throw new NotImplementedException();
        }

        public int Count { get; }

        public bool IsReadOnly => true;

        public void Add(bool item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(bool item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(bool[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(bool item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, bool item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(bool item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<bool> GetEnumerator()
        {
            return Enumerable.Range(0, Count).Select(i => this[i]).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return $"{Number}: {string.Join("", this.Select(o => o ? '1' : '0'))}";
        }
    }
}
