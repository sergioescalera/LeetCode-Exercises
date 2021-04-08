using System;
using System.Collections.Generic;

namespace LeetCode.Data
{
    public class Heap<T>
    {
        private T[] _items;
        private IComparer<T> _comparer;

        public Heap(int capacity = 10, IComparer<T> comparer = null)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];

            _comparer = comparer ?? Comparer<T>.Default;
        }

        public virtual void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            EnsureExtraCapacity();

            _items[Size] = item;

            Size++;

            HeapifyUp();
        }

        public virtual T Peek()
        {
            EnsureNotEmpty();

            return _items[0];
        }

        public virtual T Poll()
        {
            EnsureNotEmpty();

            var item = _items[0];

            _items[0] = _items[Size - 1];

            Size--;

            HeapifyDown();

            return item;
        }

        public int Capacity { get => _items.Length; }

        public int Size { get; private set; }

        #region Helpers

        private void EnsureNotEmpty()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private void EnsureExtraCapacity()
        {
            if (Size < _items.Length)
            {
                return;
            }

            var array = new T[_items.Length * 2];

            Array.Copy(_items, array, _items.Length);

            _items = array;
        }

        private void HeapifyUp()
        {
            var index = Size - 1;

            while (HasParent(index) && _comparer.Compare(Parent(index), _items[index]) > 0)
            {
                var parentIndex = GetParentIndex(index);

                Swap(parentIndex, index);

                index = parentIndex;
            }
        }

        private void HeapifyDown()
        {
            var index = 0;

            while (HasLeftChild(index))
            {
                var childIndex = GetLeftChildIndex(index);

                if (HastRightChild(index) && _comparer.Compare(RightChild(index), LeftChild(index)) < 0)
                {
                    childIndex = GetRightChildIndex(index);
                }

                if (_comparer.Compare(_items[index], _items[childIndex]) <= 0)
                {
                    break;
                }

                Swap(index, childIndex);

                index = childIndex;
            }
        }

        private void Swap(int indexOne, int indexTwo)
        {
            var temp = _items[indexOne];

            _items[indexOne] = _items[indexTwo];
            _items[indexTwo] = temp;
        }

        private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;

        private int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;

        private int GetParentIndex(int childIndex) => childIndex <= 0 ? -1 : (childIndex - 1) / 2;

        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < Size;

        private bool HastRightChild(int index) => GetRightChildIndex(index) < Size;

        private bool HasParent(int index) => GetParentIndex(index) >= 0;

        private T LeftChild(int index) => _items[GetLeftChildIndex(index)];

        private T RightChild(int index) => _items[GetRightChildIndex(index)];

        private T Parent(int index) => _items[GetParentIndex(index)];

        #endregion
    }
}
