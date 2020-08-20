using LeetCode.Attributes;
using LeetCode.Extensions;
using LeetCode.Input;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ReorderListExercise
    {
        public static void Run()
        {
            var ex = new ReorderListExercise();
            do
            {
                var list = ex.ReadList();

                ex.ReorderList(list);

                list.PrintPretty();

            } while (true);
        }
        /// <summary>
        /// Given 1->2->3->4->5, reorder it to 1->5->2->4->3.
        /// </summary>
        /// <param name="head"></param>
        public void ReorderList(ListNode head)
        {
            if (head == null)
            {
                return;
            }

            head.next = ReorderNode(head.next);
        }

        private ListNode ReorderNode(ListNode node)
        {
            if (node == null)
                return null;

            var last = FindDetachLast(node);

            last.next = last == node ? null : node;

            node.next = ReorderNode(node.next);

            return last;
        }

        private ListNode FindDetachLast(ListNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.next == null)
            {
                return node;
            }

            var prev = node;
            var current = node.next;

            while (current.next != null)
            {
                prev = current;
                current = current.next;
            }

            prev.next = null;

            return current;
        }
    }
}
