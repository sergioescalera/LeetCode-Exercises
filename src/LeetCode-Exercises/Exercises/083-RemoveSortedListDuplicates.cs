using LeetCode.Attributes;
using LeetCode.Input;

namespace LeetCode.Exercises
{
    [Exercise]
    public class RemoveSortedListDuplicates
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return null;

            head.next = DeleteDuplicates(head.next, head.val);

            return head;
        }

        private ListNode DeleteDuplicates(ListNode current, int previous)
        {
            if (current == null)
                return null;

            if (current.val == previous)
            {
                return DeleteDuplicates(current.next, previous);
            }

            current.next = DeleteDuplicates(current.next, current.val);

            return current;
        }
    }
}
