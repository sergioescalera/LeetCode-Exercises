using LeetCode.Attributes;
using LeetCode.Input;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class PalindromeLinkedList
    {
        public bool IsPalindrome(ListNode head)
        {
            if (head == null)
            {
                return true;
            }

            var len = Length(head);

            var result = IsPalindrome(head, len);

            return result.value;
        }

        private Result IsPalindrome(ListNode node, int len)
        {
            if (len <= 0)
            {
                return new Result
                {
                    value = true
                };
            }

            if (len == 1)
            {
                return new Result
                {
                    value = true,
                    next = node.next
                };
            }

            if (len == 2)
            {
                return new Result
                {
                    value = node.val == node.next.val,
                    next = node.next.next
                };
            }

            var result = IsPalindrome(node.next, len - 2);
            var next = result.next;

            result.next = next?.next;

            if (result.value == false)
            {
                return result;
            }

            result.value = node.val == next.val;

            return result;
        }

        private Int32 Length(ListNode head)
        {
            int len = 0;

            while (head != null)
            {
                len++;
                head = head.next;
            }

            return len;
        }

        class Result
        {
            public bool value;

            public ListNode next;
        }
    }
}
