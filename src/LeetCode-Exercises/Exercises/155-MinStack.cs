using System;

namespace LeetCode.Exercises
{
    public class MinStack
    {
        StackNode first;
        
        public MinStack()
        {
        }

        public void Push(int x)
        {
            var node = new StackNode
            {
                val = x
            };

            if (first == null)
            {
                first = node;
                node.min = node;
            }
            else
            {
                node.next = first;
                
                if (node.val <= first.min.val)
                {
                    node.min = node;
                }
                else
                {
                    node.min = first.min;
                }

                first = node;
            }
        }

        public void Pop()
        {
            EnsureNotEmpty();

            first = first.next;
        }

        public int Top()
        {
            EnsureNotEmpty();

            return first.val;
        }

        public int GetMin()
        {
            EnsureNotEmpty();

            return first.min.val;
        }

        private void EnsureNotEmpty()
        {
            if (first == null)
                throw new InvalidOperationException("The stack is empty");
        }

        class StackNode
        {
            public int val;

            public StackNode next;

            public StackNode min;
        }
    }
}
