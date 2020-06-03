using LeetCode.Attributes;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class FirstBadVersionExercise
    {
        private int _bad;

        public static void Run()
        {
            var n = 2126753390;
            var v = 1702766719;

            var exercise = new FirstBadVersionExercise(v);

            var r = exercise.FirstBadVersion(n);

            Console.WriteLine("Result: " + r);
        }

        public FirstBadVersionExercise(int bad)
        {
            _bad = bad;
        }

        public int FirstBadVersion(int n)
        {
            if (n <= 0)
            {
                return -1;
            }

            int start = 1;
            int end = n;

            while (start <= end)
            {
                if (IsBadVersion(start))
                    return start;

                var middle = start + (end - start) / 2;

                if (IsBadVersion(middle))
                {
                    end = middle;
                }
                else
                {
                    start = middle + 1;
                }
            }

            return -1;
        }

        private int FirstBadVersionRecursive(int start, int end)
        {
            if (IsBadVersion(start))
                return start;

            if (start >= end)
            {
                return -1;
            }

            var middle = (start + end) / 2;

            if (IsBadVersion(middle))
            {
                return FirstBadVersionRecursive(start, middle);
            }
            else
            {
                return FirstBadVersionRecursive(middle + 1, end);
            }
        }

        bool IsBadVersion(int version)
        {
            return version >= _bad;
        }
    }
}
