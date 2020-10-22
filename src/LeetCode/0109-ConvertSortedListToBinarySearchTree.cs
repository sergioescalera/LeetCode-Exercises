using LeetCode.Data;

namespace LeetCode
{
    public class ConvertSortedListToBinarySearchTree
    {
        public TreeNode SortedListToBST(ListNode head)
        {
            return SortedListToBST(head, null);
        }

        public TreeNode SortedListToBST(ListNode head, ListNode tail)
        {

            if (head == tail)
            {
                return null;
            }

            var mid = FindMid(head, tail);

            return new TreeNode(
                mid.val,
                SortedListToBST(head, mid),
                SortedListToBST(mid.next, tail));
        }

        private ListNode FindMid(ListNode start, ListNode end)
        {
            if (start == end)
            {
                return null;
            }

            var slow = start;
            var fast = start.next;

            while (fast != end && fast.next != end)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }
    }
}
