using LeetCode.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    public class RemoveNthNodeFromEndList
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (n <= 0)
                return head;

            return RemoveNthFromEnd(head, n, out var i);
        }

        private ListNode RemoveNthFromEnd(ListNode current, int n, out int i)
        {
            if (current == null)
            {
                i = 0;

                return current;
            }

            var next = RemoveNthFromEnd(current.next, n, out var j);

            i = j + 1;

            if (i == n)
            {
                return next;
            }
            else
            {
                current.next = next;

                return current;
            }
        }
    }
}
