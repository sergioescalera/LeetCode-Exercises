using LeetCode.Attributes;
using LeetCode.Extensions;
using LeetCode.Input;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class MergeKSortedLists
    {
        public static void Run()
        {
            var ex = new MergeKSortedLists();

            do
            {
                var lists = new List<ListNode>();

                do
                {
                    var node = ex.ReadList();

                    if (node == null)
                        break;

                    lists.Add(node);

                } while (true);

                if (lists.Count == 0)
                {
                    break;
                }

                var merged = ex.MergeKLists(lists.ToArray());

                merged.PrintPretty();

                Console.ReadLine();

            } while (true);
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null)
            {
                throw new ArgumentNullException();
            }

            var head = default(ListNode);
            var tail = default(ListNode);

            if (lists.Length == 1)
            {
                return lists[0];
            }

            do
            {
                var minIndex = FindMin(lists);

                if (minIndex < 0)
                {
                    break;
                }

                var node = new ListNode(lists[minIndex].val);

                if (head == null)
                {
                    head = tail = node;
                }
                else
                {
                    tail.next = node;
                    tail = node;
                }

                lists[minIndex] = lists[minIndex].next;

            } while (true);

            return head;
        }

        private Int32 FindMin(ListNode[] lists)
        {
            var minIndex = -1;
            var min = default(ListNode);

            for (int i = 0; i < lists.Length; i++)
            {
                var node = lists[i];

                if (node == null)
                {
                    continue;
                }

                if (min == null || node.val < min.val)
                {
                    min = node;
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}
