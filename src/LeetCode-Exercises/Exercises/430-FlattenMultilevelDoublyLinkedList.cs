using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    public class FlattenMultilevelDoublyLinkedList
    {
        public Node Flatten(Node head)
        {
            if (head == null)
            {
                return null;
            }

            if (head.child == null)
            {
                head.next = Flatten(head.next);
            }
            else
            {
                head.next = head.next == null ? Flatten(head.child) : Flatten(head.child, head.next);

                head.child = null;
            }

            if (head.next != null)
            {
                head.next.prev = head;
            }

            return head;
        }

        private Node Flatten(Node head, Node next)
        {
            if (head.child == null && head.next == null)
            {
                head.next = Flatten(next);

                head.next.prev = head;

                return head;
            }

            if (head.child == null)
            {
                head.next = Flatten(head.next, next);

                head.next.prev = head;

                return head;
            }

            head.next = Flatten(head.child, head.next);

            head.child = null;

            head.next.prev = head;

            head.next = Flatten(head.next, next);

            head.next.prev = head;

            return head;
        }

        public class Node
        {
            public int val;
            public Node prev;
            public Node next;
            public Node child;
        }
    }
}
