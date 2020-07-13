using LeetCode.Attributes;
using LeetCode.Extensions;
using LeetCode.Input;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SortListExercise
    {
        public static void Run()
        {
            // 4->2->1->3

            var exercise = new SortListExercise();

            do
            {
                var list = exercise.ReadList();

                if (list == null)
                    break;

                var sorted = exercise.SortList(list);

                sorted.PrintPretty();

            } while (true);
        }

        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var middle = Middle(head);
            var next = middle.next;

            middle.next = null;

            var first = SortList(head);

            var second = SortList(next);

            return Merge(first, second);
        }

        private ListNode Merge(ListNode first, ListNode second)
        {
            if (first == null)
            {
                return second;
            }

            if (second == null)
            {
                return first;
            }

            if (first.val <= second.val)
            {
                first.next = Merge(first.next, second);

                return first;
            }

            second.next = Merge(first, second.next);

            return second;
        }

        private ListNode Middle(ListNode head)
        {
            var slow = head;
            var fast = head;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }
    }
}
