using LeetCode.Data;
using System.Collections.Generic;

namespace LeetCode
{
    public class ReverseLinkedList
    {
        public ListNode ReverseList(ListNode list)
        {
            if (list == null)
            {
                return null;
            }

            var stack = new Stack<int>();

            var current = list;

            while (current != null)
            {
                stack.Push(current.val);

                current = current.next;
            }

            var head = default(ListNode);
            var tail = default(ListNode);

            while (stack.Count > 0)
            {
                if (head == null)
                {
                    head = tail = new ListNode(stack.Pop());
                }
                else
                {
                    tail.next = new ListNode(stack.Pop());
                    tail = tail.next;
                }
            }

            return head;
        }
    }
}
