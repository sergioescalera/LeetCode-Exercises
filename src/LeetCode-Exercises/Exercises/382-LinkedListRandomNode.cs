using LeetCode.Attributes;
using LeetCode.Input;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class LinkedListRandomNode
    {
        public static void Run()
        {
            var results = new Dictionary<int, int>();
            var list = new ListNode(
                0, 
                new ListNode(
                    1, 
                    new ListNode(
                        2, 
                        new ListNode(
                            3,
                            new ListNode(4)))));

            var ex = new Solution(list);

            for (int i = 0; i < 5000; i++)
            {
                var rnd = ex.GetRandom();

                if (results.ContainsKey(rnd))
                {
                    results[rnd]++;
                }
                else
                {
                    results[rnd] = 1;
                }
            }

            foreach (var pair in results)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        class Solution
        {
            private readonly ListNode _head;
            private readonly Random _rnd;
            private readonly Int32 _count;

            public Solution(ListNode head)
            {
                if (head == null)
                {
                    throw new InvalidOperationException();
                }

                _head = head;
                _rnd = new Random();
                _count = GetCount();
            }

            public int GetRandom()
            {
                var index = _rnd.Next() % _count;

                var node = FindNode(index);

                return node.val;
            }

            private ListNode FindNode(int index)
            {
                if (index < 2)
                {
                    return index == 0 ? _head : _head.next;
                }

                var i = 0;
                var node = _head;
                var count = index / 2;

                while (i <= count)
                {
                    i += 2;
                    node = node.next.next;
                }

                return index % 2 == 0 ? node : node.next;
            }

            private int GetCount()
            {
                var count = 0;
                var current = _head;

                while (current != null && current.next != null)
                {
                    count += 2;

                    current = current.next.next;
                }

                if (current != null)
                {
                    count++;
                }

                return count;
            }
        }
    }
}
