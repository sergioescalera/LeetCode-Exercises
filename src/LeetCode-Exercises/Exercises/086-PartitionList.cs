using LeetCode.Attributes;
using LeetCode.Input;

namespace LeetCode.Exercises
{
    [Exercise]
    public class PartitionList
    {
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null)
                return null;

            ListNode headEnd = null;
            ListNode tail = null;
            ListNode tailEnd = null;
            ListNode current = head;

            head = null;

            while (current != null)
            {
                var next = current.next;

                current.next = null;

                if (current.val < x)
                {
                    if (head == null)
                    {
                        head = current;
                    }
                    if (headEnd != null)
                    {
                        headEnd.next = current;
                    }
                    headEnd = current;
                }
                else
                {
                    if (tail == null)
                    {
                        tail = current;
                    }
                    if (tailEnd != null)
                    {
                        tailEnd.next = current;
                    }
                    tailEnd = current;
                }

                current = next;
            }

            if (headEnd != null && headEnd != tail)
            {
                headEnd.next = tail;
            }

            return head ?? tail;
        }
    }
}
