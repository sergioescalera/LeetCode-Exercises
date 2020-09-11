using LeetCode.Data;

namespace LeetCode
{
    public class OddEvenLinkedList
    {
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
            {
                return head;
            }

            ListNode odd = head;
            ListNode oddEnd = odd;
            ListNode even = head.next;
            ListNode evenEnd = even;

            ListNode node = even?.next;
            
            int index = 3;

            while (node != null)
            {
                if (index % 2 == 0)
                {
                    evenEnd.next = node;
                    evenEnd = node;
                }
                else
                {
                    oddEnd.next = node;
                    oddEnd = node;
                }

                node = node.next;
                index++;
            }

            oddEnd.next = even;

            if (evenEnd != null)
            {
                evenEnd.next = null;
            }
            return odd;
        }
    }
}
