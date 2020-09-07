using LeetCode.Data;
using System.Collections.Generic;

namespace LeetCode
{
    public class LinkedListCycle
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }

            var slow = head;
            var fast = head;

            while (slow.next != null
                && fast.next != null
                && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }

        bool HasCycle(ListNode node, Dictionary<int, List<ListNode>> memory)
        {
            if (node == null)
            {
                return false;
            }

            if (memory.ContainsKey(node.val))
            {
                var list = memory[node.val];

                if (list.Contains(node))
                {
                    return true;
                }

                list.Add(node);
            }
            else
            {
                memory.Add(node.val, new List<ListNode>(new[] { node }));
            }

            return HasCycle(node.next, memory);
        }
    }
}
