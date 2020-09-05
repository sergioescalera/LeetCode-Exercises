using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode.Data
{
    public class Heap<T>
    {
        private int _size;
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

            _items[_size] = item;

            _size++;

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

            _items[0] = _items[_size - 1];

            _size--;

            HeapifyDown();

            return item;
        }

        #region Helpers

        private void EnsureNotEmpty()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private void EnsureExtraCapacity()
        {
            if (_size < _items.Length)
            {
                return;
            }

            var array = new T[_items.Length * 2];

            Array.Copy(_items, array, _items.Length);

            _items = array;
        }

        private void HeapifyUp()
        {
            var index = _size - 1;

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

        private int GetParentIndex(int parentIndex) => 2 * parentIndex + 1;

        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < _size;

        private bool HastRightChild(int index) => GetRightChildIndex(index) < _size;

        private bool HasParent(int index) => GetParentIndex(index) >= 0;

        private T LeftChild(int index) => _items[GetLeftChildIndex(index)];

        private T RightChild(int index) => _items[GetRightChildIndex(index)];

        private T Parent(int index) => _items[GetParentIndex(index)];

        #endregion
    }
}
