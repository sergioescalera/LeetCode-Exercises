using LeetCode.Attributes;
using LeetCode.Extensions;
using LeetCode.Input;

namespace LeetCode.Exercises
{
    [Exercise]
    public class RemoveLinkedListElements
    {
        public static void Run()
        {
            var ex = new RemoveLinkedListElements();

            do
            {
                var list = ex.ReadList();

                if (list == null)
                    break;

                var elem = ex.ReadNum();

                if (elem == null)
                    break;

                var removed = ex.RemoveElements(list, elem.Value);

                removed.PrintPretty();

            } while (true);
        }

        public ListNode RemoveElements(ListNode head, int val)
        {

            if (head == null)
                return null;

            var next = RemoveElements(head.next, val);

            if (head.val == val)
                return next;

            head.next = next;

            return head;
        }
    }
}
