namespace LeetCode
{
    public class MyLinkedList
    {

        int count;
        ListNode head;
        ListNode tail;

        public MyLinkedList()
        {

        }

        public int Get(int index)
        {

            if (head == null)
            {
                return -1;
            }

            var node = FindNode(index);

            if (node == null)
            {
                return -1;
            }

            return node.val;
        }

        public void AddAtHead(int val)
        {

            var node = new ListNode
            {
                val = val
            };

            if (head == null)
            {

                head = tail = node;
            }
            else
            {

                node.next = head;
                head.prev = node;

                head = node;
            }

            count++;
        }

        public void AddAtTail(int val)
        {

            var node = new ListNode
            {
                val = val
            };

            if (head == null)
            {

                head = tail = node;
            }
            else
            {

                node.prev = tail;
                tail.next = node;

                tail = node;
            }

            count++;
        }

        public void AddAtIndex(int index, int val)
        {

            if (index > count)
            {
                return;
            }

            if (index == count)
            {
                AddAtTail(val);
            }

            else
            {
                var next = FindNode(index);

                if (next == null)
                {
                    return;
                }

                var node = new ListNode
                {
                    val = val,
                    next = next,
                    prev = next.prev
                };

                if (node.prev == null)
                {
                    head = node;
                }
                else
                {
                    node.prev.next = node;
                }

                next.prev = node;

                count++;
            }
        }

        public void DeleteAtIndex(int index)
        {

            var node = FindNode(index);

            if (node == null)
            {
                return;
            }

            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                var prev = node.prev;
                var next = node.next;

                if (prev == null)
                {
                    head = next;

                    next.prev = null;
                    node.next = null;
                }
                else if (next == null)
                {
                    tail = prev;

                    prev.next = null;
                    node.prev = null;
                }
                else
                {
                    node.next = null;
                    node.prev = null;

                    prev.next = next;
                    next.prev = prev;
                }
            }

            count--;
        }

        ListNode FindNode(int index)
        {

            if (index < 0 || index >= count)
            {
                return null;
            }

            var node = head;

            while (index > 0)
            {
                node = node.next;
                index--;
            }

            return node;
        }

        public override string ToString()
        {
            return head.ToString();
        }

        class ListNode
        {
            public int val;

            public ListNode next;

            public ListNode prev;

            public override string ToString()
            {
                var sep = next == null ? "" : ", ";

                return $"{val}{sep}{next}";
            }
        }
    }
}
