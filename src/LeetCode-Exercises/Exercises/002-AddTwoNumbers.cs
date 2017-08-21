using LeetCode.Attributes;
using LeetCode.Input;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public static class AddTwoNumbers
    {
        public static void Run()
        {
            var a = new ListNode(2)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(3)
                }
            };

            var b = new ListNode(5)
            {
                next = new ListNode(6)
                {
                    //next = new ListNode(4)
                }
            };

            var sum = Add(a, b);

            sum.PrintPretty();
        }

        private static ListNode Add(ListNode l1, ListNode l2)
        {
            return Add(l1, l2, false);
        }

        private static ListNode Add(ListNode l1, ListNode l2, Boolean carry)
        {
            if (l1 == null && l2 == null && !carry)
            {
                return null;
            }

            if (l1 == null && l2 == null && carry)
            {
                return new ListNode(1);
            }

            var a = l1?.val ?? 0;
            var b = l2?.val ?? 0;

            var s = a + b + (carry ? 1 : 0);

            var c = s >= 10;

            return new ListNode(c ? s - 10 : s)
            {
                next = Add(l1?.next, l2?.next, c)
            };
        }
    }
}
