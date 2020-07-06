using LeetCode.Attributes;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ImplementStackWithQueues
    {
        public static void Run()
        {
            var stack = new MyStack();

            for (int i = 1; i <= 10; i++)
            {
                stack.Push(i);
            }

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(stack.Pop());
            }

            for (int i = 11; i <= 500; i++)
            {
                stack.Push(i);
            }

            while (stack.Empty() == false)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine("press enter");
            Console.ReadLine();
        }
    }

    public class MyStack
    {
        private readonly Queue<int> oldest;
        private readonly Queue<int> newest;

        /** Initialize your data structure here. */
        public MyStack()
        {
            oldest = new Queue<int>();
            newest = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            MoveToOldest();

            oldest.Enqueue(x);
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            MoveToNewest();

            return newest.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            MoveToNewest();

            return newest.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return oldest.Count == 0 && newest.Count == 0;
        }

        private void MoveToNewest()
        {
            if (oldest.Count == 0)
            {
                return;
            }

            var item = oldest.Dequeue();

            MoveToNewest();

            newest.Enqueue(item);
        }

        private void MoveToOldest()
        {
            if (newest.Count == 0)
            {
                return;
            }

            var item = newest.Dequeue();

            MoveToOldest();

            oldest.Enqueue(item);
        }
    }
}
