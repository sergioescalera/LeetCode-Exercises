using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LeetCode.Exercises
{
    [Exercise]
    public class DinnerPlateStacks
    {
        public static void Run()
        {
            /*
1 <= capacity <= 20000
1 <= val <= 20000
0 <= index <= 100000
At most 200000 calls will be made to push, pop, and popAtStack.
             */

            var stopwatch = new Stopwatch();
            //var plates = new DinnerPlates(20000);

            //stopwatch.Start();

            //for (int i = 0; i < 200000; i++)
            //{
            //    plates.Push(i);
            //}

            //while (plates.Pop() >= 0) ;

            var d = new DinnerPlates(2);

            d.Push(1);
            d.Push(2);
            d.Push(3);
            d.Push(4);
            d.Push(5);
            d.PopAtStack(0);   
            d.Push(20); 
            d.Push(21);
            d.PopAtStack(0);
            d.PopAtStack(2);
            d.Pop();
            d.Pop();
            d.Pop();
            d.Pop();
            d.Pop();
            stopwatch.Stop();

            Console.WriteLine("Completed in {0}", stopwatch.Elapsed);
        }
    }

    public class DinnerPlates
    {
        private readonly List<Stack<int>> _stacks;
        private readonly SortedSet<int> _available;
        private readonly SortedSet<int> _notEmpty;
        private int _capacity;

        public DinnerPlates(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _capacity = capacity;

            _stacks = new List<Stack<int>>();

            _available = new SortedSet<int>();

            _notEmpty = new SortedSet<int>();
        }

        public void Push(int val)
        {
            var index = GetOrCreateStack();
            var stack = _stacks[index];

            stack.Push(val);

            if (stack.Count == _capacity)
            {
                _available.Remove(index);
            }

            if (stack.Count == 1)
            {
                _notEmpty.Add(index);
            }
        }

        public int Pop()
        {
            if (_notEmpty.Count == 0)
            {
                return -1;
            }

            var index = _notEmpty.Max;

            return PopAtStack(index);
        }

        public int PopAtStack(int index)
        {
            if (index < 0 || index >= _stacks.Count)
            {
                return -1;
            }

            var stack = _stacks[index];

            if (stack.Count == 0)
            {
                return -1;
            }

            var item = stack.Pop();

            if (stack.Count == 0)
            {
                _notEmpty.Remove(index);
            }

            if (stack.Count == _capacity - 1)
            {
                _available.Add(index);
            }

            return item;
        }

        private int GetOrCreateStack()
        {
            if (_available.Count > 0)
            {
                return _available.Min;
            }

            var index = _stacks.Count;
            var stack = new Stack<int>();

            _stacks.Add(stack);
            _available.Add(index);

            return index;
        }
    }
}
