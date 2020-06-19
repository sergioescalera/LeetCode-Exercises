using LeetCode.Attributes;
using LeetCode.Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Extensions
{
    [Exercise]
    public class RotateList
    {
        public static void Run()
        {
            var list = new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 2,
                    next = new ListNode
                    {
                        val = 3
                    }
                }
            };

            var exercise = new RotateList();

            var rotated = exercise.RotateRight(list, 3);

            rotated.PrintPretty();

            Console.ReadLine();
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (k < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(k));
            }

            if (k == 0)
            {
                return head;
            }    

            if (head == null)
            {
                return head;
            }

            var length = GetLength(head);
            var m = k % length;

            if (m == 0)
            {
                return head;
            }

            var i = length - m + 1;

            return RotateRight(head, head, 0, i);
        }

        private Int32 GetLength(ListNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + GetLength(node.next);
        }

        private ListNode RotateRight(
            ListNode node, 
            ListNode head,
            int counter, 
            int target)
        {
            counter++;

            var next = node?.next;

            if (counter == target)
            {
                node.next = RotateRight(next, head, counter, target);

                return node;
            }
            
            if (counter < target)
            {
                if (counter == target - 1)
                {
                    node.next = null;
                }

                return RotateRight(next, head, counter, target);
            }

            if (node == null)
            {
                return head;
            }

            node.next = RotateRight(next, head, counter, target);

            return node;
        }
    }
}
