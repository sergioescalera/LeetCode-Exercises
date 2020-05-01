using LeetCode.Attributes;
using LeetCode.Input;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SwapNodesInPairs
    {
        public static void Run()
        {

        }

        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var next = head.next;

            head.next = SwapPairs(next.next);

            next.next = head;

            return next;
        }
    }
}
