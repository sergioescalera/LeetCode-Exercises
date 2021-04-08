using System;
using System.Collections.Generic;

namespace LeetCode.Data
{
    public class LFUCache<TKey, TValue>
    {
        private readonly int capacity;
        private readonly Dictionary<TKey, MapNode> map;

        private HeapNode[] heap;
        private int count;
        private TValue @default;

        public LFUCache(int capacity, TValue @default = default(TValue))
        {
            this.capacity = Math.Max(capacity, 0);
            this.map = new Dictionary<TKey, MapNode>();
            this.heap = new HeapNode[this.capacity];
            this.@default = @default;
        }

        public TValue Get(TKey key)
        {
            if (capacity <= 0)
            {
                return @default;
            }

            if (!map.ContainsKey(key))
            {
                return @default;
            }

            heap[map[key].HeapIndex].IncrementFrequency();

            HeapifyDown(map[key].HeapIndex);

            return map[key].Value;
        }

        public void Put(TKey key, TValue value)
        {
            if (capacity <= 0)
            {
                return;
            }

            if (map.ContainsKey(key))
            {
                map[key].Value = value;

                heap[map[key].HeapIndex].IncrementFrequency();
                
                HeapifyDown(map[key].HeapIndex);
            }
            else
            {
                if (count < capacity)
                {
                    var heapIndex = count;

                    heap[heapIndex] = new HeapNode(key);

                    map.Add(key, new MapNode(value, heapIndex));

                    count++;

                    HeapifyUp(heapIndex);
                }
                else
                {
                    var heapIndex = 0;

                    map.Remove(heap[heapIndex].Key);

                    heap[heapIndex] = new HeapNode(key);

                    map.Add(key, new MapNode(value));

                    HeapifyDown(heapIndex);
                }
            }
        }

        #region Heap

        private void Swap(int indexOne, int indexTwo)
        {
            var temp = heap[indexOne];

            heap[indexOne] = heap[indexTwo];
            heap[indexTwo] = temp;

            map[heap[indexOne].Key].HeapIndex = indexOne;
            map[heap[indexTwo].Key].HeapIndex = indexTwo;
        }

        private void HeapifyUp(int index)
        {
            while (HasParent(index))
            {
                var parentIndex = GetParentIndex(index);
                var parent = heap[parentIndex];

                if (parent.Frequency < heap[index].Frequency)
                {
                    break;
                }

                if (parent.Frequency == heap[index].Frequency &&
                    parent.Ticks < heap[index].Ticks)
                {
                    break;
                }

                Swap(parentIndex, index);

                index = parentIndex;
            }
        }

        private void HeapifyDown(int index)
        {
            while (HasLeftChild(index))
            {
                var childIndex = GetLeftChildIndex(index);

                if (HastRightChild(index))
                {
                    var right = RightChild(index);
                    var left = LeftChild(index);

                    if (right.Frequency < left.Frequency)
                    {
                        childIndex = GetRightChildIndex(index);
                    }

                    if (right.Frequency == left.Frequency &&
                        right.Ticks < left.Ticks)
                    {
                        childIndex = GetRightChildIndex(index);
                    }
                }

                if (heap[index].Frequency < heap[childIndex].Frequency)
                {
                    break;
                }

                if (heap[index].Frequency == heap[childIndex].Frequency &&
                    heap[index].Ticks < heap[childIndex].Ticks)
                {
                    break;
                }

                Swap(index, childIndex);

                index = childIndex;
            }
        }

        private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;

        private int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;

        private int GetParentIndex(int childIndex) => childIndex <= 0 ? -1 : (childIndex - 1) / 2;

        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < count;

        private bool HastRightChild(int index) => GetRightChildIndex(index) < count;

        private bool HasParent(int index) => GetParentIndex(index) >= 0;

        private HeapNode LeftChild(int index) => heap[GetLeftChildIndex(index)];

        private HeapNode RightChild(int index) => heap[GetRightChildIndex(index)];

        private HeapNode Parent(int index) => heap[GetParentIndex(index)];

        #endregion

        class MapNode
        {
            public MapNode(TValue value, int heapIndex = 0)
            {
                Value = value;
                HeapIndex = heapIndex;
            }

            public int HeapIndex { get; set; }

            public TValue Value { get; set; }

            public override string ToString()
            {
                return $"{Value} at {HeapIndex}";
            }
        }

        class HeapNode
        {
            static long ticks = 0;

            public HeapNode(TKey key)
            {
                Key = key;

                IncrementFrequency();
            }

            public int Frequency { get; private set; }

            public long Ticks { get; private set; }

            public TKey Key { get; }

            public void IncrementFrequency()
            {
                Frequency++;
                ticks++;
                Ticks = ticks;
            }

            public override string ToString()
            {
                return $"[{Key}: {Frequency}]";
            }
        }
    }
}
