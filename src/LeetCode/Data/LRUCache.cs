using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Data
{
    public class LRUCache<TKey, TData>
    {
        protected readonly Int32 capacity;
        protected readonly Dictionary<TKey, LRUCacheEntry> map;
        protected readonly LinkedList<LRUCacheNode> list;
        protected readonly TData @default;

        public LRUCache(Int32 capacity, TData @default = default(TData))
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.capacity = capacity;
            this.map = new Dictionary<TKey, LRUCacheEntry>();
            this.list = new LinkedList<LRUCacheNode>();
            this.@default = @default;
        }

        public virtual TData Get(TKey key)
        {
            if (map.TryGetValue(key, out var entry) == false)
            {
                return @default;
            }

            MoveToFront(entry);

            return entry.Node.Value.Data;
        }

        public virtual void Put(TKey key, TData value)
        {
            if (map.TryGetValue(key, out var entry))
            {
                entry.Node.Value.Data = value;

                MoveToFront(entry);
            }
            else
            {
                var node = new LinkedListNode<LRUCacheNode>(new LRUCacheNode(key, value));
                
                entry = new LRUCacheEntry(node);

                list.AddFirst(node);
                map.Add(key, entry);

                EnsureCapacity();
            }
        }

        public override string ToString()
        {
            return string.Join(", ", list.Select(x => $"[{x.Key}, {x.Data}]"));
        }

        private void EnsureCapacity()
        {
            if (list.Count <= capacity)
            {
                return;
            }

            var last = list.Last;
            var key = last.Value.Key;

            list.Remove(last);

            if (map.ContainsKey(key))
            {
                map.Remove(key);
            }
        }

        private void MoveToFront(LRUCacheEntry entry)
        {
            var node = entry.Node;
            var key = node.Value.Key;

            list.Remove(node);

            entry.Node = list.AddFirst(node.Value);
        }

        protected class LRUCacheEntry
        {
            public LinkedListNode<LRUCacheNode> Node
            {
                get; set;
            }

            public LRUCacheEntry(LinkedListNode<LRUCacheNode> node)
            {
                Node = node;
            }

            public override string ToString() => Node?.ToString();
        }

        protected class LRUCacheNode
        {
            public TKey Key
            {
                get;
            }

            public TData Data
            {
                get; set;
            }

            public LRUCacheNode(TKey key, TData data)
            {
                Key = key;
                Data = data;
            }

            public override string ToString()
            {
                return $"[{Key}, {Data}]";
            }
        }
    }
}
