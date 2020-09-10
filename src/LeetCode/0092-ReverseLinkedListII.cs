using LeetCode.Data;

namespace LeetCode
{
    public class ReverseLinkedListII
    {
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null || m < 1 || n < 1 || m >= n)
            {
                return head;
            }

            var index = 1;

            var node = head;
            var tail = head;

            while (node.next != null)
            {
                if (index < m)
                {
                    tail = node;
                    node = node.next;
                    index++;

                    continue;
                }

                var reversed = Reverse(node, n - m, out var _);

                if (node == head)
                {
                    return reversed;
                }
                else
                {
                    tail.next = reversed;

                    return head;
                }
            }

            return head;
        }

        private ListNode Reverse(ListNode node, int count, out ListNode tail)
        {
            if (count == 0 || node.next == null)
            {
                tail = node;

                return node;
            }

            var reversed = Reverse(node.next, count - 1, out tail);

            node.next = tail.next;
            tail.next = node;
            tail = node;

            return reversed;
        }
    }
}
