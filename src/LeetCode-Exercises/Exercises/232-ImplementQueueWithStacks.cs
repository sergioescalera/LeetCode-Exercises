using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ImplementQueueWithStacks
    {
        public static void Run()
        {

        }
    }

    public class MyQueue
    {
        private readonly Stack<int> newest;
        private readonly Stack<int> oldest;

        /** Initialize your data structure here. */
        public MyQueue()
        {
            newest = new Stack<int>();
            oldest = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            newest.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            MoveToOldest();

            return oldest.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            MoveToOldest();

            return oldest.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return newest.Count == 0 && oldest.Count == 0;
        }

        private void MoveToOldest()
        {
            if (oldest.Count == 0)
            {
                while (newest.Count > 0)
                {
                    oldest.Push(newest.Pop());
                }
            }
        }
    }
}
